namespace OnlyJournal.Data.Journal
{
	public interface IJournalRepository
	{
		Journal Get(string key);
		JournalArticle[] GetAllArticles();
	}
}
