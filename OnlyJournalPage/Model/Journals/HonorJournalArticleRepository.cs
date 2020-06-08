using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Journals
{
    public class HonorJournalArticleRepository : ArrayListArticleRepositoryBase<Journal, JournalArticle>
    {
        public HonorJournalArticleRepository(ISaveDataRepository save) : base(save)
        {
        }

        protected override IEnumerable<JournalArticle> CreateContents(OnlyJournalContext context)
        {
            return context.Journal.Where(x => x.Category == JournalCategory.Honor)
                .OrderBy(x => GetRandom())
                .Select(x => new JournalArticle(x));
        }

        protected override string GetKey() => $"Honor";
    }
}
