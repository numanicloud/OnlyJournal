using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalMvc.Data;

namespace OnlyJournalMvc.Views.Journals
{
    public class DetailsModel : PageModel
    {
        private readonly OnlyJournalMvc.Data.OnlyJournalMvcContext _context;

        public DetailsModel(OnlyJournalMvc.Data.OnlyJournalMvcContext context)
        {
            _context = context;
        }

        public Journal Journal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal.FirstOrDefaultAsync(m => m.ID == id);

            if (Journal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
