using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
	public interface IArticleTypeInfo
	{
		int TypeWeight { get; }
		ArticleType Type { get; }
		string PageDirectoryName { get; }
		int? GetAnyId(OnlyJournalContext context);
	}

	public abstract class ArticleTypeInfo<T> : IArticleTypeInfo where T : class
	{
		public int TypeWeight { get; }
		public ArticleType Type { get; }
		public string PageDirectoryName { get; }

		protected abstract DbSet<T> GetDB(OnlyJournalContext context);
		protected abstract int SelectId(T entity);
		protected abstract object SelectOrderKey(T entity);

		public ArticleTypeInfo(int typeWeight, ArticleType type, string pageDirectoryName)
		{
			TypeWeight = typeWeight;
			Type = type;
			PageDirectoryName = pageDirectoryName;
		}

		public int? GetAnyId(OnlyJournalContext context)
		{
			var entity = GetDB(context).AsEnumerable()
				.Where(x => !context.Article.Any(y => y.Type == (int)Type && y.ContentId == SelectId(x)))
				.OrderByDescending(SelectOrderKey)
				.FirstOrDefault();

			if (entity != null)
			{
				return SelectId(entity);
			}
			else
			{
				return null;
			}
		}
	}
}
