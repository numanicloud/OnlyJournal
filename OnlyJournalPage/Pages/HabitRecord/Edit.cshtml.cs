using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class EditModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public EditModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OnlyJournal.Data.Habit.HabitRecord HabitRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HabitRecord = await _context.HabitRecord.FirstOrDefaultAsync(m => m.Id == id);

            if (HabitRecord == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HabitRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitRecordExists(HabitRecord.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HabitRecordExists(string id)
        {
            return _context.HabitRecord.Any(e => e.Id == id);
        }
    }
}
