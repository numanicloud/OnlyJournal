using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Data.Surfing;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.SaveData;
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
        private readonly ISaveDataRepository _save;
        private IEnumerable<IArticle> cache = null;

        protected IRandomValueSource Random { get; }

        public ArrayListArticleRepositoryBase(ISaveDataRepository save, IRandomValueSource random)
        {
            this._save = save;
            this.Random = random;
        }

        public int GetCount(IContentsContext context)
        {
            cache = cache ?? CreateContents(context);
            return cache.Count();
        }

        public IArticle GetNextArticle(IContentsContext context)
        {
            cache = cache ?? CreateContents(context);
            var contents = cache;
            var count = contents.Count();

            if (count == 0)
            {
                return null;
            }

            var surfingSave = _save.GetSurfingState();
            EnsureProgressKey(surfingSave);

            var index = surfingSave.Progresses[GetKey()] % count;
            var next = contents.ElementAt(index);

            surfingSave.Progresses[GetKey()] = index > int.MaxValue / 2 ? 0 : index + 1;
            _save.Save();

            return next;
        }

        private void EnsureProgressKey(SurfingState surfingSave)
        {
            if (!surfingSave.Progresses.ContainsKey(GetKey()))
            {
                surfingSave.Progresses[GetKey()] = 0;
                _save.Save();
            }
        }

        protected abstract IEnumerable<TArticle> CreateContents(IContentsContext context);
        protected abstract string GetKey();
    }
}
