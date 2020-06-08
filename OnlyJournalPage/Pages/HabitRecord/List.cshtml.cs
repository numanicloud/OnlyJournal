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
using HabitData = OnlyJournal.Data.Habit.HabitRecord;

namespace OnlyJournalPage.Pages.HabitRecord
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
        public HabitData[] Habits { get; set; }
        [BindProperty]
        public Data.Todo.Todo ImportantTodo { get; set; }
        [BindProperty]
        public bool DoSurfing { get; set; }
        [BindProperty]
        public int StaySeconds { get; set; }
        [BindProperty]
        public bool IsCompletedHabits { get; set; }

        public async Task OnGetAsync([FromQuery] bool surfing = true)
        {
            Habits = context.HabitRecord.ToArray();
            DoSurfing = surfing;
            StaySeconds = options.CurrentValue.HabitStaySeconds;
            ImportantTodo = await todoPartial.GetImportantTodoAsync();
        }
    }
}