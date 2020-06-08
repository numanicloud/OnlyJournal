using OnlyJournal.Data.Journal;
using OnlyJournalPage.Model.Article;

namespace OnlyJournalPage.Model.Journals
{
    public class JournalArticle : IArticle
    {
        private readonly Journal journal;

        public Journal Data => journal;

        public JournalArticle(Journal journal)
        {
            this.journal = journal;
        }

        public string GetPagePath() => "/Journal/Article";

        public object GetQueryValue() => new { id = journal.Id };
    }
}
