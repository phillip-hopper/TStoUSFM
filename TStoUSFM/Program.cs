using System;
using System.Windows.Forms;

namespace TS2USFM
{
	public static class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);

			try
			{
				Application.Run(new MainForm());
			}
			finally
			{
				FinalCleanup();
			}
		}

		/// <summary>
		/// This function runs when the application is shutting down.
		/// </summary>
		private static void FinalCleanup()
		{
			// clean-up code goes here
		}
	}
}
