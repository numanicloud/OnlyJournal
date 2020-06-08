using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Journals
{
    public class TechJournalArticleRepository : ArrayListArticleRepositoryBase<Journal, JournalArticle>
    {
        protected override IEnumerable<JournalArticle> CreateContents(OnlyJournalContext context)
        {
            var random = new Random();
            return context.Journal.Where(x => x.Category == JournalCategory.Tech)
                .OrderByDescending(x => random.Next())
                .Select(x => new JournalArticle(x));
        }

        protected override DbSet<Journal> GetDB(OnlyJournalContext context) => context.Journal;

        protected override int GetId(JournalArticle item) => item.Data.Id;
    }
}
