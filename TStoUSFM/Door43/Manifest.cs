using System.Collections.Generic;

namespace TS2USFM.Door43
{
	class Manifest
	{
		public decimal package_version;
		public string format;
		public Generator generator;
		public Language target_language;
		public IdAndName project;
		public IdAndName type;
		public IdAndName resource;
		public List<Translation> source_translations;
		public object parent_draft;
		public List<string> translators;
		public List<string> finished_chunks;
	}

	struct Generator
	{
		public string name;
		public string build;
	}

	struct Language
	{
		public string id;
		public string name;
		public string direction;
	}

	struct IdAndName
	{
		public string id;
		public string name;
	}

	struct Translation
	{
		public string language_id;
		public string resource_id;
		public string checking_level;
		public string date_modified;
		public string version;
	}
}
