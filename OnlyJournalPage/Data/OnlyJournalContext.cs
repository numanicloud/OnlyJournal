using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data.Todo;

namespace OnlyJournalPage.Data
{
	public class OnlyJournalContext : DbContext
	{
		public OnlyJournalContext (DbContextOptions<OnlyJournalContext> options)
			: base(options)
		{
		}

		public DbSet<OnlyJournal.Data.Journal.Journal> Journal { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Journal>()
				.Property(x => x.Id)
				.HasDefaultValue(0);
		}

		public DbSet<OnlyJournal.Data.Habit.HabitRecord> HabitRecord { get; set; }

		public DbSet<OnlyJournalPage.Data.Todo.Todo> Todo { get; set; }
	}
}
