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
    public class IndexModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public IndexModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        public IList<OnlyJournalPage.Data.Todo.Todo> Todo { get;set; }

        public async Task OnGetAsync()
        {
            Todo = await _context.Todo.ToListAsync();
        }
    }
}
