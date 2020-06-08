using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
    public abstract class ArrayListArticleRepositoryBase<TEntity, TArticle> : IArticleRepository
        where TEntity : class
        where TArticle : class, IArticle
    {
        private List<TArticle> contents;
        private int currentIndex = 0;

        public int ArticleAmount => contents.Count;

        public void Initialize(OnlyJournalContext context)
        {
            contents = new List<TArticle>(CreateContents(context));
        }

        public async Task OnRecordDeletedAsync(ArticleType type, int id)
        {
            var article = contents.FirstOrDefault(x => GetId(x) == id);
            contents.Remove(article);
        }

        public IArticle GetNextArticle()
        {
            if (!contents.Any())
            {
                return null;
            }

            var next = contents[currentIndex];
            currentIndex = (currentIndex + 1) % contents.Count;
            return next;
        }

        protected abstract IEnumerable<TArticle> CreateContents(OnlyJournalContext context);
        protected abstract DbSet<TEntity> GetDB(OnlyJournalContext context);
        protected abstract int GetId(TArticle item);
    }
}
