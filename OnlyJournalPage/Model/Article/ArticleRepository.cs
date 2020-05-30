using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleData = OnlyJournalPage.Data.Article.Article;

namespace OnlyJournalPage.Model.Article
{
	public class ArticleRepository
	{
		private readonly Random random = new Random();
		private readonly JournalTypeInfo journalType;
		private readonly HabitTypeInfo habitType;
		private readonly TodoTypeInfo todoType;

		// DB内のオブジェクトではなく、そのクローンを溜めておく
		private readonly List<ArticleData> instances = new List<ArticleData>();

		public ArticleRepository()
		{
			this.journalType = new JournalTypeInfo();
			this.habitType = new HabitTypeInfo();
			this.todoType = new TodoTypeInfo();
		}

		public async Task<ArticleData> TryCreateArticleAsync(OnlyJournalContext context)
		{
			var t = GetContentId(context);
			if (t is null)
			{
				return null;
			}

			var article = new ArticleData()
			{
				ContentId = t.Value.id,
				Type = (int)t.Value.type,
			};
			context.Article.Add(article);
			await context.SaveChangesAsync();

			// 本物のデータではなくてクローンを使う
			instances.Add(new ArticleData
			{
				ContentId = article.ContentId,
				Type = article.Type,
				PriorityDiff = -1
			});

			return article;
		}

		public async Task<ArticleData> TryGetArticleAsync(OnlyJournalContext context)
		{
			ArticleData data = null;
			if (instances.All(x => x.PriorityDiff < 0))
			{
				data = await context.Article.Where(x => x.Type == 0)
					.Where(x => !instances.Contains(x))
					.FirstOrDefaultAsync();

				if (data != null)
				{
					instances.Add(data);
				}
			}

			if (data == null)
			{
				data = instances.OrderByDescending(x => x.PriorityDiff).FirstOrDefault();
			}

			if (data == null)
			{
				return null;
			}

			data.PriorityDiff -= 1;
			return data;
		}

		private (ArticleType type, int id)? GetContentId(OnlyJournalContext context)
		{
			var info = new List<IArticleTypeInfo>() { journalType, habitType, todoType };

			while (info.Any())
			{
				var r = random.Next() % 10;
				int totalWeight = 0;
				for (int i = info.Count - 1; i >= 0; i--)
				{
					var p = info[i];
					if (r <= p.TypeWeight + totalWeight)
					{
						if (p.GetAnyId(context) is int id)
						{
							return (p.Type, id);
						}
						else
						{
							info.RemoveAt(i);
						}
					}
				}
			}
			return null;
		}
	}
}
