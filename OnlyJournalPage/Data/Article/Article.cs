using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Article
{
	public class Article
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int ContentId { get; set; }
		public int Type { get; set; }
		[NotMapped]
		public int PriorityDiff { get; set; }
	}
}
