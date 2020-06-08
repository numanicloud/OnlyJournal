using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
    public interface IArticleRepository
    {
        void Initialize(OnlyJournalContext context);
        IArticle GetNextArticle();
        Task OnRecordDeletedAsync(ArticleType type, int id);
    }
}
