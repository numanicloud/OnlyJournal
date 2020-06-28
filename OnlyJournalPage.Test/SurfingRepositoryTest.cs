using OnlyJournalPage.Data.Surfing;
using OnlyJournalPage.Model.Common;
using OnlyJournalPage.Model.Options;
using OnlyJournalPage.Model.SaveData;
using OnlyJournalPage.Model.Surfing;
using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace OnlyJournalPage.Test
{
    public class SurfingRepositoryTest
    {
        private IArticleRepositoryStore repoStore;
        private readonly ISaveDataRepository save;
        private readonly ITestOutputHelper output;

        public SurfingRepositoryTest(ITestOutputHelper output)
        {
            repoStore = new MockArticleRepositoryStore()
            {
                DailyJournal = MockArticleRepo(0),
                HonorJournal = MockArticleRepo(100),
                TechJournal = MockArticleRepo(200),
                GeneralHabit = MockArticleRepo(300),
                HabitList = MockArticleRepo(400),
                CompletedHabit = MockArticleRepo(500),
                Todo = MockArticleRepo(600),
            };
            save = new MockSaveDataRepository();

            this.output = output;
        }

        private MockArticleRepository MockArticleRepo(int randomBase)
        {
            return new MockArticleRepository(new ConstantRandomValueSource(randomBase));
        }

        [Fact]
        public void 想定した順番でリポジトリが選ばれる()
        {
            var actual = new (string, object)[]
            {
                ("/Mock/Article", 0),
                ("/Mock/Article", 300),
                ("/Mock/Article", 1),
                ("/Mock/Article", 301),
                ("/Mock/Article", 2),
                ("/Mock/Article", 302),
                ("/Mock/Article", 600),
                ("/Mock/Article", 200),
                ("/Mock/Article", 303),
                ("/Mock/Article", 201),
            };

            for (int i = 0; i < 10; i++)
            {
                output.WriteLine($"loop: {i}");

                var subject = new SurfingRepository(repoStore,
                    save,
                    new ConstantRandomValueSource(0),
                    new MockContext(),
                    null);
                var saveData = save.GetSurfingState();

                output.WriteLine($"globalProgress: {saveData.GlobalProgress}");

                var (page, query) = subject.GetNextPage();

                output.WriteLine($"({page}, {query})");

                Assert.Equal(actual[i].Item1, page);
                Assert.Equal((int)actual[i].Item2, (int)query);
            }
        }
    }
}
