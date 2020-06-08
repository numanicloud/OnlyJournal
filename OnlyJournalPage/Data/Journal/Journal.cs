using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyJournal.Data.Journal
{
	public enum JournalCategory
    {
		Daily, Honor, Tech
    }

	public class Journal
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Markdown { get; set; }
		[HiddenInput]
		public DateTime TimeCreated { get; set; }
		[Required]
        public JournalCategory Category { get; set; }

        [NotMapped]
		public string MarkDownPreview { get; set; }
	}
}
