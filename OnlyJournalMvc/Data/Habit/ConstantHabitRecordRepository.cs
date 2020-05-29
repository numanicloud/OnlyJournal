using OnlyJournal.Data.Article;

namespace OnlyJournal.Data.Habit
{
	public class ConstantHabitRecordRepository : IHabitRecordRepository
	{
		public HabitRecord Get(string key)
		{
			return new HabitRecord { Title = "リオレウスを討伐", SuccessCount = 12 };
		}

		public IArticle[] GetAllArticleInfo()
		{
			return new IArticle[]
			{
				new HabitArticle("リオレウスを討伐")
			};
		}
	}
}
