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
    public class DeleteModel : PageModel
    {
        private readonly OnlyJournalMvc.Data.OnlyJournalMvcContext _context;

        public DeleteModel(OnlyJournalMvc.Data.OnlyJournalMvcContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            }

            return RedirectToPage("./Index");
        }
    }
}
