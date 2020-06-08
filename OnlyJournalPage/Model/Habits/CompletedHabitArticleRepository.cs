using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Model.Article;
using System;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class CompletedHabitArticleRepository : IArticleRepository
    {
        private HabitListArticle article;

        public async Task OnRecordDeletedAsync(ArticleType type, int id)
        {
            // Do nothing
        }

        public IArticle GetNextArticle()
        {
            return article;
        }

        public void Initialize(OnlyJournalContext context)
        {
            article = new HabitListArticle(true);
        }
    }
}
