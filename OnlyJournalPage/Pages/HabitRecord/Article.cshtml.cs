using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model;
using OnlyJournalPage.Model.Options;
using HabitData = OnlyJournal.Data.Habit.HabitRecord;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class ArticleModel : PageModel
    {
		private readonly OnlyJournalContext context;
        private readonly IOptionsMonitor<ArticleOption> options;
        private readonly TodoPartialViewModel todoPartial;

		public ArticleModel(OnlyJournalContext context, IOptionsMonitor<ArticleOption> options)
		{
			this.context = context;
            this.options = options;
            todoPartial = new TodoPartialViewModel(context);
		}

        [BindProperty]
		public HabitData Habit { get; set; }
		[BindProperty]
		public Data.Todo.Todo ImportantTodo { get; set; }
		[BindProperty]
        public bool DoSurfing { get; set; }
		[BindProperty]
        public int StaySeconds { get; set; }

        public async Task<IActionResult> OnGet(int? id, [FromQuery]bool surfing = true)
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
			DoSurfing = surfing;
			StaySeconds = options.CurrentValue.HabitStaySeconds;

			return Page();
        }
    }
}
