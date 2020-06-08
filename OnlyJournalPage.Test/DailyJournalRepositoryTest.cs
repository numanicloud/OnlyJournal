using OnlyJournalPage.Model.Journals;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlyJournalPage.Test
{
    public class DailyJournalRepositoryTest
    {
        [Fact]
        public void 正しい順番で記事が選ばれる()
        {
            var save = new MockSaveDataRepository();
            var random = new ConstantRandomValueSource(0);

            var expecteds = new[] { 0, 1, 2, 3, 4 };

            for (int i = 0; i < expecteds.Length; i++)
            {
                var subject = new DailyJournalArticleRepository(save, random);
                var article = subject.GetNextArticle(new MockContext());
                Assert.Equal("/Journal/Article", article.GetPagePath());
                Assert.Equal($"{{ id = {expecteds[i]} }}", article.GetQueryValue().ToString());
            }
        }
    }
}
