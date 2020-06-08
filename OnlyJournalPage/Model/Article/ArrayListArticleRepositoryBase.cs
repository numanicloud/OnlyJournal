using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Data.Surfing;
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

        protected Random Random { get; private set; }

        public ArrayListArticleRepositoryBase(ISaveDataRepository save)
        {
            this._save = save;
        }

        public int GetCount(OnlyJournalContext context)
        {
            cache = cache ?? CreateContents(context);
            return cache.Count();
        }

        public IArticle GetNextArticle(OnlyJournalContext context)
        {
            cache = cache ?? CreateContents(context);
            var contents = cache;
            var count = contents.Count();

            if (count == 0)
            {
                return null;
            }

            var surfingSave = _save.GetSurfingState();
            var index = surfingSave.Progresses[GetKey()] % count;
            var next = contents.ElementAt(index);

            surfingSave.Progresses[GetKey()] = index + 1;
            _save.Save();

            return next;
        }

        protected int GetRandom()
        {
            if (Random == null)
            {
                var data = _save.GetSurfingState();
                if (!data.RandomSeed.ContainsKey(GetKey()))
                {
                    data.RandomSeed[GetKey()] = DateTime.Now.GetHashCode();
                    _save.Save();
                }
                   
                Random = new Random(data.RandomSeed[GetKey()]);
            }

            return Random.Next();
        }

        protected abstract IEnumerable<TArticle> CreateContents(OnlyJournalContext context);
        protected abstract string GetKey();
    }
}
