using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Todos
{
    public class TodoArticleRepository : IArticleRepository
    {
        public IArticle GetNextArticle()
        {
            return new TodoArticle();
        }

        public void Initialize(OnlyJournalContext context)
        {
        }

        public async Task OnRecordDeletedAsync(ArticleType type, int id)
        {
            // Do nothing
        }
    }
}
