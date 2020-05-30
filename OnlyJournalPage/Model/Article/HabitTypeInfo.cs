using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
	public class HabitTypeInfo : ArticleTypeInfo<HabitRecord>
	{
		public HabitTypeInfo() : base(5, ArticleType.Habit, "/HabitRecord")
		{
		}

		protected override DbSet<HabitRecord> GetDB(OnlyJournalContext context) => context.HabitRecord;

		protected override int SelectId(HabitRecord entity) => entity.Id;

		protected override object SelectOrderKey(HabitRecord entity) => 0;
	}
}
