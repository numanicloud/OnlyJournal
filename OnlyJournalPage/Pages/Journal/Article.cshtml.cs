using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model;
using OnlyJournalPage.Model.Options;

namespace OnlyJournalPage.Pages.Journal
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
            this.todoPartial = new TodoPartialViewModel(context);
		}

        [BindProperty]
        public string ResultingHtml { get; set; }
		[BindProperty]
		public Data.Todo.Todo ImportantTodo { get; set; }
		[BindProperty]
        public bool DoSurfing { get; set; }
		[BindProperty]
        public int StaySeconds { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, [FromQuery]bool surfing = true)
        {
			if (id == null)
			{
                return NotFound();
			}

            var journal = await context.Journal.FirstOrDefaultAsync(m => m.Id == id);

			if (journal == null)
			{
				return NotFound();
			}

			ResultingHtml = JournalHelper.GetHtml(journal);
			ImportantTodo = await todoPartial.GetImportantTodoAsync();
			DoSurfing = surfing;
			StaySeconds = options.CurrentValue.JournalStaySeconds;

			return Page();
        }
    }
}
