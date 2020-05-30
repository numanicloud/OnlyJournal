using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
			foreach (var item in Journal)
			{
                item.MarkDownPreview = item.Markdown.Substring(0, Math.Min(20, item.Markdown.Length));
			}
        }
    }
}
