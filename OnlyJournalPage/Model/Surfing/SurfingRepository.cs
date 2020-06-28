using Microsoft.Extensions.Options;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.Habits;
using OnlyJournalPage.Model.Journals;
using OnlyJournalPage.Model.Options;
using OnlyJournalPage.Model.SaveData;
using OnlyJournalPage.Model.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Surfing
{
	public class SurfingRepository : ISurfingRepository
	{
		private readonly IArticleRepositoryStore repos;
		private readonly ISaveDataRepository save;
		private readonly IRandomValueSource random;
		private readonly IContentsContext context;
		private readonly IOptionsMonitor<ArticleOption> option;
		private readonly IEnumerator<IArticleRepository> sequence;

		public SurfingRepository(IArticleRepositoryStore repos,
			ISaveDataRepository save,
			IRandomValueSource random,
			IContentsContext context,
			IOptionsMonitor<ArticleOption> option)
		{
			this.repos = repos;
			this.save = save;
			this.random = random;
			this.context = context;
			this.option = option;
			this.sequence = GetArticleRepositories().GetEnumerator();
		}

		public (string path, object queryString) GetNextPage()
		{
			var surfingSave = save.GetSurfingState();
			var modulo = 3 * 2 + 1;
			var index = surfingSave.GlobalProgress % modulo + 1;

			for (int i = 0; i < index; i++)
			{
				sequence.MoveNext();
			}
			var current = sequence.Current.GetNextArticle(context);

			surfingSave.GlobalProgress += 1;
			if (surfingSave.GlobalProgress >= int.MaxValue / 2)
			{
				surfingSave.GlobalProgress = 0;
			}
			save.Save();

			return (current.GetPagePath(), current.GetQueryValue());
		}

		private IEnumerable<IArticleRepository> GetArticleRepositories()
		{
			var journalSequence = GetNextJournal().GetEnumerator();
			var habitSequence = GetNextHabit().GetEnumerator();

			while (true)
			{
				for (int i = 0; i < option.CurrentValue.HabitAndJournalRepeatCount; i++)
				{
					journalSequence.MoveNext();
					yield return journalSequence.Current;

					for (int j = 0; j < option.CurrentValue.HabitRepeatCount; j++)
					{
						habitSequence.MoveNext();
						yield return habitSequence.Current;
					}
				}
				yield return repos.Todo;
			}

			IEnumerable<IArticleRepository> GetNextJournal()
			{
				var densities = new[]
				{
					MathF.Sqrt(repos.DailyJournal.GetCount(context)),
					MathF.Sqrt(repos.HonorJournal.GetCount(context)),
					MathF.Sqrt(repos.TechJournal.GetCount(context)),
				};

				while (true)
				{
					var index = Helper.GetRandomIndex(densities, random);
					yield return index switch
					{
						0 => repos.DailyJournal,
						1 => repos.HonorJournal,
						_ => repos.TechJournal,
					};
				}
			}

			IEnumerable<IArticleRepository> GetNextHabit()
			{
				while (true)
				{
					var count = repos.GeneralHabit.GetCount(context);
					for (int i = 0; i < count; i++)
					{
						yield return repos.GeneralHabit;
					}
					yield return repos.HabitList;
					yield return repos.CompletedHabit;
				}
			}
		}
	}
}
