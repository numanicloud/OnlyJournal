using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.Surfing;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockArticleRepositoryStore : IArticleRepositoryStore
    {
        public IArticleRepository DailyJournal { get; set; }

        public IArticleRepository HonorJournal { get; set; }

        public IArticleRepository TechJournal { get; set; }

        public IArticleRepository GeneralHabit { get; set; }

        public IArticleRepository HabitList { get; set; }

        public IArticleRepository CompletedHabit { get; set; }

        public IArticleRepository Todo { get; set; }
    }
}
