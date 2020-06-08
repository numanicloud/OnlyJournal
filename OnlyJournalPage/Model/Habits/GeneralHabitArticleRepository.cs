using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class GeneralHabitArticleRepository : ArrayListArticleRepositoryBase<HabitRecord, HabitArticle>
    {
        protected override IEnumerable<HabitArticle> CreateContents(OnlyJournalContext context)
        {
            var random = new Random();
            return context.HabitRecord.Where(x => !x.IsCompleted)
                .OrderBy(x => random.Next())
                .Select(x => new HabitArticle(x));
        }

        protected override DbSet<HabitRecord> GetDB(OnlyJournalContext context) => context.HabitRecord;

        protected override int GetId(HabitArticle item) => item.Data.Id;
    }
}
