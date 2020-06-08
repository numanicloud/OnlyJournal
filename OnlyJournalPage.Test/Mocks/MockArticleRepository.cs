using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockArticleRepository : IArticleRepository
    {
        private readonly IRandomValueSource random;

        public MockArticleRepository(IRandomValueSource random)
        {
            this.random = random;
        }

        public int GetCount(IContentsContext context)
        {
            return 10;
        }

        public IArticle GetNextArticle(IContentsContext context)
        {
            return new MockArticle(random.Next(0, 1000));
        }
    }
}
