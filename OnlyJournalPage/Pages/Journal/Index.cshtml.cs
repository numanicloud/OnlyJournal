using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OnlyJournalPage.Pages.Journal
{
	public class IndexModel : PageModel
    {
        private readonly OnlyJournalPage.Data.OnlyJournalContext _context;

        public IndexModel(OnlyJournalPage.Data.OnlyJournalContext context)
        {
            _context = context;
        }

        public IList<OnlyJournal.Data.Journal.Journal> Journal { get;set; }

        public async Task OnGetAsync()
        {
            Journal = await _context.Journal.ToListAsync();
        }
    }
}
