using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Todo
{
	public class Todo
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime BeginTime { get; set; }
		public DateTime EndTime { get; set; }
		public bool IsFinishByEndTime { get; set; }
		public bool IsFinished { get; set; }
	}
}
