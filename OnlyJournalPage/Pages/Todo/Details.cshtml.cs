using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Todo;

namespace OnlyJournalPage.Pages.Todo
{
    public class DetailsModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public DetailsModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        public OnlyJournalPage.Data.Todo.Todo Todo { get; set; }

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
    }
}
