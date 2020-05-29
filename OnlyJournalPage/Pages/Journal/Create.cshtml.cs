using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;

namespace OnlyJournalPage.Pages.Journal
{
    public class CreateModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public CreateModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OnlyJournal.Data.Journal.Journal Journal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Journal.Add(Journal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
