namespace OnlyJournal.Data.Journal
{
	public class ConstantJournalRepository : IJournalRepository
	{
		public Journal Get(string key)
		{
			return new Journal
			{
				Markdown = @"
# Header1

Text

## Header2

Text

---

Text",
			};
		}

		public JournalArticle[] GetAllArticles()
		{
			return new JournalArticle[]
			{
				new JournalArticle("<constant>"),
			};
		}
	}
}
