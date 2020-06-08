using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Todo;
using OnlyJournalPage.Model.Article;

namespace OnlyJournalPage.Pages.Todo
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
        public Data.Todo.Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);

            if (Todo == null)
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

            Todo = await _context.Todo.FindAsync(id);

            if (Todo != null)
            {
                _context.Todo.Remove(Todo);
                await _context.SaveChangesAsync();

                foreach (var item in repositories)
                {
                    await item.OnRecordDeletedAsync(Data.Article.ArticleType.Todo, Todo.Id);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
