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
    public class IndexModel : PageModel
    {
        private readonly OnlyJournalMvc.Data.OnlyJournalMvcContext _context;

        public IndexModel(OnlyJournalMvc.Data.OnlyJournalMvcContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; }

        public async Task OnGetAsync()
        {
            Journal = await _context.Journal.ToListAsync();
        }
    }
}
