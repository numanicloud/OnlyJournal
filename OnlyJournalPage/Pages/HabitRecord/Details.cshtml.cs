using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class DetailsModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public DetailsModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OnlyJournal.Data.Habit.HabitRecord HabitRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
    }
}
