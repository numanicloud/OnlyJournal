using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Data.Journal;
using OnlyJournalPage.Data.Todo;
using System.Collections.Generic;
using JournalData = OnlyJournal.Data.Journal.Journal;

namespace OnlyJournalPage.Data
{
	public class OnlyJournalContext : DbContext, IContentsContext
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
			modelBuilder.Entity<JournalData>().ToTable("Journals");
			modelBuilder.Entity<HabitRecord>().ToTable("Habits");
			modelBuilder.Entity<Todo.Todo>().ToTable("Todo");
			modelBuilder.Entity<Article.Article>().ToTable("Articles");
		}

        public DbSet<JournalData> Journal { get; set; }

		public DbSet<HabitRecord> HabitRecord { get; set; }

		public DbSet<Todo.Todo> Todo { get; set; }

		public DbSet<Article.Article> Article { get; set; }

        #region Implementation
        public abstract class Repo<TRecord>
		{
			public IEnumerable<TRecord> Items { get; set; }
			public IEnumerable<TRecord> GetAll() => Items;
		}
		public class HabitRepo : Repo<HabitRecord>, IHabitRecordRepository
		{
		}
		public class JournalRepo : Repo<JournalData>, IJournalRepository
		{
		}
		public class TodoRepo : Repo<Todo.Todo>, ITodoRepository
		{
		}

		public IHabitRecordRepository Habits => new HabitRepo { Items = HabitRecord };

        public IJournalRepository Journals => new JournalRepo { Items = Journal };

        public ITodoRepository Todos => new TodoRepo { Items = Todo };
        #endregion
    }
}
