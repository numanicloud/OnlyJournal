using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model
{
	public class TodoPartialViewModel
	{
		private readonly OnlyJournalContext context;

		public TodoPartialViewModel(OnlyJournalContext context)
		{
			this.context = context;
		}

		public async Task<Data.Todo.Todo> GetImportantTodoAsync()
		{
			return context.Todo
				.AsEnumerable()
				.OrderByDescending(x => GetPriority(x))
				.FirstOrDefault();
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
