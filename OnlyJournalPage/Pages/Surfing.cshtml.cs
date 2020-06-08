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
using OnlyJournalPage.Model.Surfing;

namespace OnlyJournalPage.Pages
{
    public class SurfingModel : PageModel
    {
        private readonly ISurfingRepository repository;
        private readonly OnlyJournalContext context;

        public SurfingModel(ISurfingRepository repository, OnlyJournalContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        public IActionResult OnGet()
		{
			var (page, query) = repository.GetNextPage(context);
			return RedirectToPage(page, query);
		}
    }
}
