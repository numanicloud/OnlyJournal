using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class HabitListArticleRepository : IArticleRepository
    {
        public int GetCount(IContentsContext context) => 1;

        public IArticle GetNextArticle(IContentsContext context)
        {
            return new HabitListArticle(false);
        }
    }
}
