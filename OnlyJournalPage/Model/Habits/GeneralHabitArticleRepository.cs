using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class GeneralHabitArticleRepository : ArrayListArticleRepositoryBase<HabitRecord, HabitArticle>
    {
        public GeneralHabitArticleRepository(ISaveDataRepository save, IRandomValueSource random) : base(save, random)
        {
        }

        protected override IEnumerable<HabitArticle> CreateContents(IContentsContext context)
        {
            return context.Habits.GetAll().Where(x => !x.IsCompleted)
                //.OrderBy(x => Random.Next())
                .Select(x => new HabitArticle(x));
        }

        protected override string GetKey() => "GeneralHabit";
    }
}
