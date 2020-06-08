using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Habits
{
    public class HabitListArticleRepository : IArticleRepository
    {
        public IArticle GetNextArticle(OnlyJournalContext context)
        {
            return new HabitListArticle(false);
        }
    }
}
