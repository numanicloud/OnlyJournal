using Microsoft.EntityFrameworkCore;

namespace OnlyJournalPage.Data
{
	public class OnlyJournalContext : DbContext
	{
		public OnlyJournalContext (DbContextOptions<OnlyJournalContext> options)
			: base(options)
		{
		}

		public DbSet<OnlyJournal.Data.Journal.Journal> Journal { get; set; }

		public DbSet<OnlyJournal.Data.Habit.HabitRecord> HabitRecord { get; set; }

		public DbSet<Todo.Todo> Todo { get; set; }

		public DbSet<Article.Article> Article { get; set; }
	}
}
