using OnlyJournal.Data.Habit;
using OnlyJournal.Data.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournal.Data.Article
{
	public class SimpleArticleRepository : IArticleRepository
	{
		private readonly IHabitRecordRepository habits;
		private readonly IJournalRepository journals;

		private IArticle[] articles = null;

		public SimpleArticleRepository(IHabitRecordRepository habits,
			IJournalRepository journals)
		{
			this.habits = habits;
			this.journals = journals;
		}

		public IArticle GetNext()
		{
			if (articles is null)
			{
				var has = habits.GetAllArticleInfo();
				var jas = journals.GetAllArticles();
				articles = has.Cast<IArticle>().Concat(jas).ToArray();
			}

			var result = articles.OrderByDescending(x => x.Priority).First();
			result.OnShown();
			return result;
		}
	}
}
