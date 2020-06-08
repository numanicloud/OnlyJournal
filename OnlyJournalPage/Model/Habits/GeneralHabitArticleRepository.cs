using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class GeneralHabitArticleRepository : ArrayListArticleRepositoryBase<HabitRecord, HabitArticle>
    {
        public GeneralHabitArticleRepository(ISaveDataRepository save) : base(save)
        {
        }

        protected override IEnumerable<HabitArticle> CreateContents(OnlyJournalContext context)
        {
            return context.HabitRecord.Where(x => !x.IsCompleted)
                .OrderBy(x => GetRandom())
                .Select(x => new HabitArticle(x));
        }

        protected override string GetKey() => "GeneralHabit";
    }
}
