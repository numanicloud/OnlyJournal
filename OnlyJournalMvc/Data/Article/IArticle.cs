namespace OnlyJournal.Data.Article
{
	public interface IArticle
	{
		string LinkName { get; }
		string Key { get; }
		int Priority { get; }
		void OnShown();
	}
}
