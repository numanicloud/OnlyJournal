using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OnlyJournalPage.Pages.HabitRecord
{
	public class IndexModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public IndexModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        public IList<OnlyJournal.Data.Habit.HabitRecord> HabitRecord { get;set; }

        public async Task OnGetAsync()
        {
            HabitRecord = await _context.HabitRecord.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
			if (!ModelState.IsValid)
			{
                return Page();
			}

            var subject = await _context.HabitRecord.FirstOrDefaultAsync(x => x.Id == id);
            subject.SuccessCount += 1;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
