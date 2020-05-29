using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using OnlyJournal.Data.Article;

namespace OnlyJournal.Data.Habit
{
	public class CsvHabitRecordRepository : IHabitRecordRepository
	{
		private readonly string filePath;
		private HabitRecord[] cache = null;

		public CsvHabitRecordRepository(HabitOption option)
		{
			this.filePath = option.FilePath;
		}

		public HabitRecord Get(string key)
		{
			if (cache is null)
			{
				LoadCache();
			}

			return cache.FirstOrDefault(x => x.Key == key);
		}

		private void LoadCache()
		{
			using var textReader = new StreamReader(filePath);
			using var reader = new CsvReader(textReader, CultureInfo.InvariantCulture);
			cache = reader.GetRecords<HabitRecord>().ToArray();
		}

		public IArticle[] GetAllArticleInfo()
		{
			if (cache is null)
			{
				LoadCache();
			}

			return cache.Select(x => new HabitArticle(x.Key) { Priority = 1000 }).ToArray();
		}
	}
}
