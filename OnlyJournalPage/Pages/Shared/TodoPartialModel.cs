using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Pages.Shared
{
	public class TodoPartialModel : PageModel
	{
		private readonly OnlyJournalContext context;

		public TodoPartialModel(OnlyJournalContext context)
		{
			this.context = context;
		}

		[BindProperty]
		public Data.Todo.Todo Subject { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			Subject = await context.Todo
				.OrderByDescending(x => GetPriority(x))
				.FirstOrDefaultAsync();

			if (Subject == null)
			{
				return NotFound();
			}
			return Page();
		}

		private double GetPriority(Data.Todo.Todo x)
		{
			var pivot = x.BeginTime ?? x.EndTime ?? DateTime.MinValue;
			var sub = (pivot - DateTime.Now).TotalMilliseconds;

			// 負の数ならタイムオーバーなので、優先度は最小
			// さもなくば、subが小さいほど高優先度
			return sub < 0 ? double.MinValue : -sub;
		}
	}
}
