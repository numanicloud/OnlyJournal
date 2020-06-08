using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using OnlyJournalPage.Data;
using OnlyJournalPage.Model;
using OnlyJournalPage.Model.Options;
using TodoData = OnlyJournalPage.Data.Todo.Todo;

namespace OnlyJournalPage.Pages.Todo
{
    public class ListModel : PageModel
    {
        private readonly OnlyJournalContext context;
        private readonly IOptionsMonitor<ArticleOption> options;
        private TodoPartialViewModel todoPartial;

        public ListModel(OnlyJournalContext context, IOptionsMonitor<ArticleOption> options)
        {
            this.context = context;
            this.options = options;
            todoPartial = new TodoPartialViewModel(context);
        }

        [BindProperty]
        public TodoData[] Todos { get; set; }
        [BindProperty]
        public TodoData ImportantTodo { get; set; }
        [BindProperty]
        public bool DoSurfing { get; set; }
        [BindProperty]
        public int StaySeconds { get; set; }

        public async Task OnGetAsync([FromQuery] bool surfing = true)
        {
            Todos = context.Todo.ToArray();
            DoSurfing = surfing;
            StaySeconds = options.CurrentValue.TodoStaySeconds;
            ImportantTodo = await todoPartial.GetImportantTodoAsync();
        }
    }
}