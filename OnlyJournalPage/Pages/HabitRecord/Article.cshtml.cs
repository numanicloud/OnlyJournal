using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model;
using HabitData = OnlyJournal.Data.Habit.HabitRecord;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class ArticleModel : PageModel
    {
		private readonly OnlyJournalContext context;
		private readonly TodoPartialViewModel todoPartial;

		public ArticleModel(OnlyJournalContext context)
		{
			this.context = context;
			todoPartial = new TodoPartialViewModel(context);
		}

        [BindProperty]
		public HabitData Habit { get; set; }
		[BindProperty]
		public Data.Todo.Todo ImportantTodo { get; set; }

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

			ImportantTodo = await todoPartial.GetImportantTodoAsync();

			return Page();
        }
    }
}
