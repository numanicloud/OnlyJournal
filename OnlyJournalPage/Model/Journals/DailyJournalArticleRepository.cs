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
    public class DailyJournalArticleRepository : ArrayListArticleRepositoryBase<Journal, JournalArticle>
    {
        protected override IEnumerable<JournalArticle> CreateContents(OnlyJournalContext context)
        {
            return context.Journal.Where(x => x.Category == OnlyJournal.Data.Journal.JournalCategory.Daily)
                .OrderByDescending(x => x.TimeCreated)
                .Select(x => new JournalArticle(x));
        }

        protected override DbSet<Journal> GetDB(OnlyJournalContext context)
        {
            return context.Journal;
        }

        protected override int GetId(JournalArticle item)
        {
            return item.Data.Id;
        }
    }
}
