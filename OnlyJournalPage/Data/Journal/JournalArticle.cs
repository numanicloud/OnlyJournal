using OnlyJournal.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournal.Data.Journal
{
	public class JournalArticle : IArticle
	{
		public string LinkName => "/Journal";

		public string Key { get; }

		public int Priority { get; set; } = 0;

		public JournalArticle(string fileName)
		{
			Key = fileName;
		}

		public void OnShown()
		{
			Priority += -1;
		}
	}
}
