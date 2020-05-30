using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyJournal.Data.Article
{
	public interface IArticle
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		int Id { get; }
		int Type { get; }
		int BasePriority { get; }
		int PriorityDiff { get; }
		void OnShown();
	}
}
