using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
