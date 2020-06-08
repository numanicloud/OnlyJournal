using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournal.Data.Journal;

namespace OnlyJournalPage.Data
{
	public class OnlyJournalContext : DbContext
	{
        public OnlyJournalContext()
        {
        }

		public OnlyJournalContext (DbContextOptions<OnlyJournalContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=OnlyJournalDB.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Journal>().ToTable("Journals");
			modelBuilder.Entity<HabitRecord>().ToTable("Habits");
			modelBuilder.Entity<Todo.Todo>().ToTable("Todo");
			modelBuilder.Entity<Article.Article>().ToTable("Articles");
		}

		public DbSet<Journal> Journal { get; set; }

		public DbSet<HabitRecord> HabitRecord { get; set; }

		public DbSet<Todo.Todo> Todo { get; set; }

		public DbSet<Article.Article> Article { get; set; }
	}
}
