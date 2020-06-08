using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Habits;
using OnlyJournalPage.Model.Journals;
using OnlyJournalPage.Model.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Surfing
{
    public class SurfingRepository : ISurfingRepository
    {
        private IEnumerator<IArticleRepository> sequence;

        public SurfingRepository(OnlyJournalContext context)
        {
            sequence = GetArticleRepositories(context).GetEnumerator();
        }

        public (string path, object queryString) GetNextPage()
        {
            sequence.MoveNext();
            var current = sequence.Current.GetNextArticle();
            return (current.GetPagePath(), current.GetQueryString());
        }

        private IEnumerable<IArticleRepository> GetArticleRepositories(OnlyJournalContext context)
        {
            var daily = new DailyJournalArticleRepository();
            var honor = new HonorJournalArticleRepository();
            var tech = new TechJournalArticleRepository();
            var habit = new GeneralHabitArticleRepository();
            var completed = new CompletedHabitArticleRepository();
            var habitList = new HabitListArticleRepository();
            var todo = new TodoArticleRepository();
            var journalSequence = GetNextJournal().GetEnumerator();
            var habitSequence = GetNextHabit().GetEnumerator();

            var repos = new IArticleRepository[] { daily, honor, tech, habit, completed, habitList, todo };
            foreach (var item in repos)
            {
                item.Initialize(context);
            }

            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    journalSequence.MoveNext();
                    yield return journalSequence.Current;

                    habitSequence.MoveNext();
                    yield return habitSequence.Current;
                }
                yield return todo;
            }

            IEnumerable<IArticleRepository> GetNextJournal()
            {
                var densities = new[]
                {
                    MathF.Sqrt(daily.ArticleAmount),
                    MathF.Sqrt(honor.ArticleAmount),
                    MathF.Sqrt(tech.ArticleAmount),
                };
                var random = new Random();

                while (true)
                {
                    var index = Helper.GetRandomIndex(densities, random);
                    yield return index switch
                    {
                        0 => daily,
                        1 => honor,
                        _ => tech,
                    };
                }
            }

            IEnumerable<IArticleRepository> GetNextHabit()
            {
                while (true)
                {
                    for (int i = 0; i < habit.ArticleAmount; i++)
                    {
                        yield return habit;
                    }
                    yield return habitList;
                    yield return completed;
                }
            }
        }
    }
}
