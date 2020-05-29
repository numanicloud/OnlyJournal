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
    public class DetailsModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public DetailsModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

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
    }
}
