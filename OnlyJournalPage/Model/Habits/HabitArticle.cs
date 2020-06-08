using OnlyJournal.Data.Habit;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class HabitArticle : IArticle
    {
        public HabitArticle(HabitRecord habit)
        {
            Data = habit;
        }

        public HabitRecord Data { get; }

        public string GetPagePath() => "/HabitRecord/Article";

        public object GetQueryValue() => new { id = Data.Id };
    }
}
