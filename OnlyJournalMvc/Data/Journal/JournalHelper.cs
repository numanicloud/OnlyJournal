using HeyRed.MarkdownSharp;

namespace OnlyJournal.Data.Journal
{
	public static class JournalHelper
	{
		public static string GetHtml(Journal journal)
		{
			Markdown markdown = new Markdown();
			markdown.AddExtension(new TableExtension());
			return markdown.Transform(journal.Markdown);
		}
	}
}
