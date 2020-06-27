using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Todo
{
	public class Todo
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PriorTimeBegin { get; set; }
		public DateTime PriorTimeEnd { get; set; }

		// 計算用キャッシュ
		[NotMapped]
		public DateTime? PriorTimeCenter { get; set; }
	}
}
