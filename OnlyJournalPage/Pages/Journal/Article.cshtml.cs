using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;

namespace OnlyJournalPage.Pages.Journal
{
    public class ArticleModel : PageModel
    {
		private readonly OnlyJournalContext context;

		public ArticleModel(OnlyJournalContext context)
		{
			this.context = context;
		}

        [BindProperty]
        public string ResultingHtml { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

			return Page();
        }
    }
}
