using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model.Options;
using TodoData = OnlyJournalPage.Data.Todo.Todo;

namespace OnlyJournalPage.Pages.Todo
{
    public class ArticleModel : PageModel
    {
        private readonly OnlyJournalContext context;
        private readonly IOptionsMonitor<ArticleOption> options;

        public ArticleModel(OnlyJournalContext context, IOptionsMonitor<ArticleOption> options)
        {
            this.context = context;
            this.options = options;
        }

        [BindProperty]
        public TodoData[] Data { get; set; }
        public TodoData ImportantTodo { get; set; }
        [BindProperty]
        public bool DoSurfing { get; set; }
        [BindProperty]
        public int StaySeconds { get; set; }

        public void OnGet(int? id, [FromQuery]bool surfing = true)
        {
            Data = context.Todo.ToArray();
            DoSurfing = surfing;
            StaySeconds = options.CurrentValue.TodoStaySeconds;
        }
    }
}