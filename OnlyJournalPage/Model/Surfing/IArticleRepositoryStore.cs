using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Surfing
{
    public interface IArticleRepositoryStore
    {
        IArticleRepository DailyJournal { get; }
        IArticleRepository HonorJournal { get; }
        IArticleRepository TechJournal { get; }
        IArticleRepository GeneralHabit { get; }
        IArticleRepository HabitList { get; }
        IArticleRepository CompletedHabit { get; }
        IArticleRepository Todo { get; }
    }
}
