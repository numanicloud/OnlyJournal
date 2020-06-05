using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Model.Article;

namespace OnlyJournalPage.Pages
{
    public class SurfingModel : PageModel
    {
		private readonly OnlyJournalContext context;
		private readonly ArticleRepository repo;
		private readonly Random random;
		private readonly JournalTypeInfo journalType;
		private readonly HabitTypeInfo habitType;
		private readonly TodoTypeInfo todoType;

		public SurfingModel(OnlyJournalContext context, ArticleRepository repo)
		{
			this.context = context;
			this.repo = repo;
			this.random = new Random();

			this.journalType = new JournalTypeInfo();
			this.habitType = new HabitTypeInfo();
			this.todoType = new TodoTypeInfo();
		}

        public async Task<IActionResult> OnGet()
		{
			Article article;
			if (random.Next() % 2 == 0)
			{
				article = await repo.TryGetArticleAsync(context)
					?? await repo.TryCreateArticleAsync(context);
			}
			else
			{
				article = await repo.TryCreateArticleAsync(context)
					?? await repo.TryGetArticleAsync(context);
			}

			if (article == null)
			{
				return NotFound();
			}

			var articleType = (ArticleType)article.Type switch
			{
				ArticleType.Journal => (IArticleTypeInfo)journalType,
				ArticleType.Habit => habitType,
				ArticleType.Todo => todoType,
				_ => throw new Exception(),
			};

			return RedirectToPage(articleType.PageDirectoryName + $"/Article",
				new { id = article.ContentId });
		}
    }
}
