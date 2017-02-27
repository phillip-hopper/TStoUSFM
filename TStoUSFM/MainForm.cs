using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TS2USFM.Door43;

namespace TS2USFM
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void _addButton_Click(object sender, EventArgs e)
		{
			var test = _repositoryURL.Text.Trim();
			if (string.IsNullOrEmpty(test))
				return;

			var urls = _repositoryURL.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var repoUrl in urls)
			{
				if (!_repositoryList.Items.Contains(repoUrl))
				{
					_repositoryList.Items.Add(repoUrl);
					_repositoryURL.Text = string.Empty;
				}
			}
		}

		private void _removeButton_Click(object sender, EventArgs e)
		{
			if ((_repositoryList.Items.Count == 0) || (_repositoryList.SelectedIndex < 0))
				return;

			_repositoryList.Items.RemoveAt(_repositoryList.SelectedIndex);
		}

		private void _browseButton_Click(object sender, EventArgs e)
		{
			using (var dlg = new FolderBrowserDialog())
			{
				var testDir = _outputDirectory.Text;
				if (Directory.Exists(testDir))
					dlg.SelectedPath = testDir;

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					_outputDirectory.Text = dlg.SelectedPath;
				}
			}
		}

		private void _goButton_Click(object sender, EventArgs e)
		{
			// warn of possible file over-write
			var outDir = _outputDirectory.Text.Trim();
			if (Directory.Exists(outDir))
			{
				var result = MessageBox.Show("Existing files will be replaced in the output directory. Do you want to continue?", "Replace Files?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.No)
					return;
			}

			Directory.CreateDirectory(Path.Combine(outDir, "usfm"));

		    var tempDir = Path.Combine(Path.GetTempPath(), "ts_download");

		    // if temp directory exists, delete it
		    if (Directory.Exists(tempDir))
		        Directory.Delete(tempDir, true);

		    // if it still exists, complain
		    if (Directory.Exists(tempDir))
		        throw new IOException("Not able to remove old temp directory: " + tempDir);

		    Directory.CreateDirectory(tempDir);

			// initialize meta data
			Meta meta = null;

			// deserialize USFM book data
			var bookData = GetBookData();

			// for splitting on verse markers
			var verseRegex = new Regex(@"(.)(\\v\s)");
			var whiteSpaceRegex = new Regex(@"(\s+)(" + Environment.NewLine + ")");
			var paragraphRegex = new Regex(@"(\\c 1" + Environment.NewLine + ")");
			var bridgeRegex = new Regex(@"\\v\s([0-9]{1,3})(?:\s*\\v\s([0-9]{1,3}))+");

			try
			{
				// loop through the list of repositories to combine
				for (var i = 0; i < _repositoryList.Items.Count; i++)
				{
					// get download link from repository URL
					var repoUrl = (string)_repositoryList.Items[i];

					if (repoUrl.EndsWith(".git"))
						repoUrl = repoUrl.Remove(repoUrl.Length - 4);

					if (repoUrl.EndsWith("/"))
						repoUrl = repoUrl.Remove(repoUrl.Length - 1);

					// get repository name
					var repoName = repoUrl.Substring(repoUrl.LastIndexOf('/') + 1);
					var downloadedZipFile = Path.Combine(tempDir, repoName + ".zip");

					_statusLabel.Text = string.Format("Processing {0}...", repoName);
					Application.DoEvents();

					// download repository
					using (var client = new WebClient())
					{
						client.DownloadFile(new Uri(repoUrl + "/archive/master.zip"), downloadedZipFile);
					}

					// unzip
					ZipFile.ExtractToDirectory(downloadedZipFile, tempDir);

					// read manifest
					var unzippedRepoDir = Path.Combine(tempDir, repoName);
					var manifestFile = Path.Combine(unzippedRepoDir, "manifest.json");
					Manifest manifest;

					using (StreamReader reader = new StreamReader(manifestFile))
					{
						string json = reader.ReadToEnd();
						manifest = JsonConvert.DeserializeObject<Manifest>(json);
					}

					// get book ID and name
					var bookID = manifest.project.id.ToUpper();
					var bookName = string.Empty;
					var chapterPad = (bookID == "PSA") ? 3 : 2;
					var bookNameFile = Path.Combine(unzippedRepoDir, "0".PadLeft(chapterPad, '0'), "title.txt");

					if (File.Exists(bookNameFile))
						bookName = File.ReadAllText(bookNameFile).Trim();

					if (string.IsNullOrEmpty(bookName))
						bookName = manifest.project.name;

					// get meta data
					if (meta == null)
						meta = MetaFromManifest(manifest);

					AddContributorsToMeta(meta, manifest);

					// combine into a single USFM file
					var usfm = new StringBuilder();
					usfm.AppendLine(@"\id " + bookID + " " + manifest.resource.name);
					usfm.AppendLine(@"\ide UTF-8");
					usfm.AppendLine(@"\h " + bookName);
					usfm.AppendLine(@"\toc1 " + bookName);
					usfm.AppendLine(@"\toc2 " + bookName);
					usfm.AppendLine(@"\toc3 " + manifest.project.id);
					usfm.AppendLine(@"\mt1 " + bookName);

					var currentChapter = 1;
					var chapterDir = Path.Combine(unzippedRepoDir, currentChapter.ToString().PadLeft(chapterPad, '0'));
					while (Directory.Exists(chapterDir))
					{
						foreach (var fileName in Directory.EnumerateFiles(chapterDir).OrderBy(filename => filename))
						{
							// test for 01.txt pattern
							if (Path.GetExtension(fileName) != ".txt")
								continue;

							var testFile = Path.GetFileNameWithoutExtension(fileName);
							if (!testFile.All(char.IsDigit))
								continue;

							var chunkText = File.ReadAllText(fileName);
							chunkText = verseRegex.Replace(chunkText, "$1" + Environment.NewLine + "$2");
							chunkText = whiteSpaceRegex.Replace(chunkText, "$2");
							chunkText = paragraphRegex.Replace(chunkText, "$1\\p" + Environment.NewLine);
							chunkText = bridgeRegex.Replace(chunkText, ReplaceVerseBridge);
							usfm.AppendLine(chunkText);
						}

						currentChapter++;
						chapterDir = Path.Combine(unzippedRepoDir, currentChapter.ToString().PadLeft(chapterPad, '0'));
					}

					// write the new USFM file, like 01-GEN-EN.usfm
					var usfmFile = string.Format("{0}-{1}-{2}.usfm", bookData[bookID][1], bookID, manifest.target_language.id.ToUpper());
					File.WriteAllText(Path.Combine(outDir, "usfm", usfmFile), usfm.ToString());
				}

				// write meta.json
				var metaJson = JsonConvert.SerializeObject(meta, Formatting.Indented);
				File.WriteAllText(Path.Combine(outDir, "meta.json"), metaJson);
			}
			finally
			{
				if (Directory.Exists(tempDir))
					Directory.Delete(tempDir, true);
			}

			_statusLabel.Text = "Ready.";
			Application.DoEvents();

			MessageBox.Show("Finished.");
		}

		private static Dictionary<string, string[]> GetBookData()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = string.Format("{0}.Resources.Books.json", assembly.GetName().Name);

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				string json = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);
			}
		}

		private static Meta MetaFromManifest(Manifest manifest)
		{
			return new Meta
			{
				lang = manifest.target_language.id,
				name = manifest.resource.name + " - " + manifest.target_language.name,
				slug = manifest.resource.id,
				checking_entity = string.Empty,
				checking_level = "1",
				publish_date = DateTime.Today.ToString("yyyyMMdd"),
				source_text = manifest.source_translations[0].language_id + " " + manifest.source_translations[0].resource_id,
				source_text_version = manifest.source_translations[0].version,
				version = manifest.source_translations[0].version + ".1"
			};
		}

		private static void AddContributorsToMeta(Meta meta, Manifest manifest)
		{
			foreach (var contributor in manifest.translators)
			{
				if (string.IsNullOrEmpty(contributor))
					continue;

				var cleaned = contributor.Trim();

				if (string.IsNullOrEmpty(cleaned))
					continue;

				if (!meta.contributors.Contains(cleaned))
				{
					meta.contributors.Add(cleaned);
				}
			}
		}

		private static string ReplaceVerseBridge(Match match)
		{
			var verses = new List<int>();

			for (var i = 1; i < match.Groups.Count; i++)
			{
				var group = match.Groups[i];

				foreach (var capture in group.Captures)
				{
					if (capture is Group)
					{
						var g = (Group)capture;
						verses.Add(int.Parse(g.Value));
					}
					else
					{
						var c = (Capture)capture;
						verses.Add(int.Parse(c.Value));
					}
				}
			}

			// return something like \v 20-22
			return @"\v " + verses.Min().ToString() + "-" + verses.Max().ToString();
		}
	}
}
