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
        IArticle GetNextArticle(OnlyJournalContext context);
    }
}
