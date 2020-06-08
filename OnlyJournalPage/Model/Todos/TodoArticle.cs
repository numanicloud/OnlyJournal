using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Todos
{
    public class TodoArticle : IArticle
    {
        public string GetPagePath() => $"/Todo/List";

        public object GetQueryValue() => null;
    }
}
