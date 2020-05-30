using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlyJournalPage.Pages.HabitRecord
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
		public OnlyJournal.Data.Habit.HabitRecord HabitRecord { get; set; }

		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			HabitRecord.SuccessCount = 0;

			_context.HabitRecord.Add(HabitRecord);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
