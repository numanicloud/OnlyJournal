using OnlyJournal.Data.Habit;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class HabitListArticle : IArticle
    {
        private readonly bool isCompleted;

        public HabitListArticle(bool isCompleted)
        {
            this.isCompleted = isCompleted;
        }

        public string GetPagePath() => $"/HabitRecord/List";

        public object GetQueryValue() => new { isCompleted };
    }
}
