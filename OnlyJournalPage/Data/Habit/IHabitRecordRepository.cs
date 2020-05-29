using OnlyJournal.Data.Article;

namespace OnlyJournal.Data.Habit
{
	public interface IHabitRecordRepository
	{
		HabitRecord Get(string key);
		IArticle[] GetAllArticleInfo();
	}
}
