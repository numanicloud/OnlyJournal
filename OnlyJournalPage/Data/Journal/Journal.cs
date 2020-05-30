using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyJournal.Data.Journal
{
	public class Journal
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Markdown { get; set; }
		public DateTime TimeCreated { get; set; }
	}
}
