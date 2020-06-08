using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Habits;
using OnlyJournalPage.Model.Journals;
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
        private readonly ArticleRepositoryStore repos;
        private readonly ISaveDataRepository save;

        public SurfingRepository(ArticleRepositoryStore repos, ISaveDataRepository save)
        {
            this.repos = repos;
            this.save = save;
        }

        public (string path, object queryString) GetNextPage(OnlyJournalContext context)
        {
            var surfingSave = save.GetSurfingState();
            var index = surfingSave.GlobalProgress;

            var current = GetArticleRepositories(context).ElementAt(index).GetNextArticle(context);
            return (current.GetPagePath(), current.GetQueryString());
        }

        private IEnumerable<IArticleRepository> GetArticleRepositories(OnlyJournalContext context)
        {
            var data = save.GetSurfingState();
            if (!data.RandomSeed.ContainsKey("Surfing"))
            {
                data.RandomSeed["Surfing"] = DateTime.Now.GetHashCode();
                save.Save();
            }
            var random = new Random(data.RandomSeed["Surfing"]);

            var journalSequence = GetNextJournal().GetEnumerator();
            var habitSequence = GetNextHabit().GetEnumerator();

            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    journalSequence.MoveNext();
                    yield return journalSequence.Current;

                    habitSequence.MoveNext();
                    yield return habitSequence.Current;
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
