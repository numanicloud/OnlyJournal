using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Article;

namespace OnlyJournalPage.Pages.HabitRecord
{
    public class DeleteModel : PageModel
    {
        private readonly OnlyJournalContext _context;
        private readonly IEnumerable<IArticleRepository> repositories;

        public DeleteModel(OnlyJournalContext context, IEnumerable<IArticleRepository> repositories)
        {
            _context = context;
            this.repositories = repositories;
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HabitRecord = await _context.HabitRecord.FindAsync(id);

            if (HabitRecord != null)
            {
                _context.HabitRecord.Remove(HabitRecord);
                await _context.SaveChangesAsync();

                foreach (var item in repositories)
                {
                    await item.OnRecordDeletedAsync(Data.Article.ArticleType.Habit, HabitRecord.Id);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
