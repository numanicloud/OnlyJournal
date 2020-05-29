using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyJournal.Data.Habit
{
	public class HabitRecord
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string Title { get; set; }
		public int SuccessCount { get; set; }
	}
}
