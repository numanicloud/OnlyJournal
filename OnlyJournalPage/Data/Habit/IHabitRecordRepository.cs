using OnlyJournal.Data.Article;
using System.Collections.Generic;

namespace OnlyJournal.Data.Habit
{
	public interface IHabitRecordRepository
	{
		IEnumerable<HabitRecord> GetAll();
	}
}
