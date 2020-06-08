using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockArticle : IArticle
    {
        private readonly int id;

        public MockArticle(int id)
        {
            this.id = id;
        }

        public string GetPagePath() => "/Mock/Article";

        public object GetQueryValue() => id;
    }
}
