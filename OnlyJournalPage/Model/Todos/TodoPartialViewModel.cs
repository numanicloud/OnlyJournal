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

		private double GetPriority(Data.Todo.Todo entity)
		{
			double nearnessFactor = 0.15;   // 前後1時間の範囲では0.15以上の優先度を持つ
			var now = DateTime.Now;

			if (entity.PriorTimeCenter is null)
			{
				entity.PriorTimeCenter = entity.PriorTimeBegin + (entity.PriorTimeEnd - entity.PriorTimeBegin) / 2;
			}

			var nearness = (now - entity.PriorTimeCenter).Value.TotalSeconds / 60.0;
			var insideness = entity.PriorTimeBegin < now && now < entity.PriorTimeEnd ? 1 : 0;
			return insideness + 1 / nearness * nearnessFactor;
		}
	}
}
