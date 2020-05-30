using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using HabitData = OnlyJournal.Data.Habit.HabitRecord;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class ArticleModel : PageModel
    {
		private readonly OnlyJournalContext context;

		public ArticleModel(OnlyJournalContext context)
		{
			this.context = context;
		}

        [BindProperty]
		public HabitData Habit { get; set; }

		public async Task<IActionResult> OnGet(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			Habit = await context.HabitRecord.FirstOrDefaultAsync(x => x.Id == id);

			if (Habit == null)
			{
				return NotFound();
			}

			return Page();
        }
    }
}
