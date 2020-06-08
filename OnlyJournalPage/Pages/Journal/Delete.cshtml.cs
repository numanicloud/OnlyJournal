using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;

namespace OnlyJournalPage.Pages.Journal
{
    public class DeleteModel : PageModel
    {
        private readonly OnlyJournalContext _context;
        private readonly IEnumerable<IArticleRepository> repositories;

        public DeleteModel(OnlyJournalContext context, IEnumerable<IArticleRepository> repositories)
        {
            _context = context;
            this.repositories = repositories;
        }

        [BindProperty]
        public OnlyJournal.Data.Journal.Journal Journal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal.FirstOrDefaultAsync(m => m.Id == id);

            if (Journal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal.FindAsync(id);

            if (Journal != null)
            {
                _context.Journal.Remove(Journal);
                await _context.SaveChangesAsync();

                foreach (var item in repositories)
                {
                    await item.OnRecordDeletedAsync(Data.Article.ArticleType.Journal, Journal.Id);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
