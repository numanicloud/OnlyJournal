using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
    public interface IArticleRepository
    {
        int GetCount(IContentsContext context);
        IArticle GetNextArticle(IContentsContext context);
    }
}
