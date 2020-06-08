using OnlyJournalPage.Model.Habits;
using OnlyJournalPage.Model.Journals;
using OnlyJournalPage.Model.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
    public class ArticleRepositoryStore
    {
        public DailyJournalArticleRepository DailyJournal { get; }
        public HonorJournalArticleRepository HonorJournal { get; }
        public TechJournalArticleRepository TechJournal { get; }
        public GeneralHabitArticleRepository GeneralHabit { get; }
        public HabitListArticleRepository HabitList { get; }
        public CompletedHabitArticleRepository CompletedHabit { get; }
        public TodoArticleRepository Todo { get; }

        public IEnumerable<IArticleRepository> Repositories => new IArticleRepository[]
        {
            DailyJournal, HonorJournal, TechJournal,
            GeneralHabit, HabitList, CompletedHabit,
            Todo
        };

        public ArticleRepositoryStore(DailyJournalArticleRepository daily,
            HonorJournalArticleRepository honor,
            TechJournalArticleRepository tech,
            GeneralHabitArticleRepository general,
            HabitListArticleRepository habitList,
            CompletedHabitArticleRepository completed,
            TodoArticleRepository todo)
        {
            DailyJournal = daily;
            HonorJournal = honor;
            TechJournal = tech;
            GeneralHabit = general;
            HabitList = habitList;
            CompletedHabit = completed;
            Todo = todo;
        }
    }
}
