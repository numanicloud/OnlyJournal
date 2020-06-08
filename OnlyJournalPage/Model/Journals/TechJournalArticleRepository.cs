using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Journals
{
    public class TechJournalArticleRepository : ArrayListArticleRepositoryBase<Journal, JournalArticle>
    {
        public TechJournalArticleRepository(ISaveDataRepository save, IRandomValueSource random) : base(save, random)
        {
        }

        protected override IEnumerable<JournalArticle> CreateContents(IContentsContext context)
        {
            return context.Journals.GetAll().Where(x => x.Category == JournalCategory.Tech)
                .OrderByDescending(x => Random.Next())
                .Select(x => new JournalArticle(x));
        }

        protected override string GetKey() => "Tech";
    }
}
