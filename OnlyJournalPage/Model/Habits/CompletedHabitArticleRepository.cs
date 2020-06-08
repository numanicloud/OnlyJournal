using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Model.Article;
using System;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class CompletedHabitArticleRepository : IArticleRepository
    {
        public IArticle GetNextArticle(OnlyJournalContext context)
        {
            return new HabitListArticle(true);
        }
    }
}
