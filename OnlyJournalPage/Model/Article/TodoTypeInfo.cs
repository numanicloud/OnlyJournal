using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using OnlyJournalPage.Data.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
	public class TodoTypeInfo : ArticleTypeInfo<Todo>
	{
		public TodoTypeInfo() : base(1, ArticleType.Todo, "/Todo", 15000)
		{
		}

		protected override DbSet<Todo> GetDB(OnlyJournalContext context) => context.Todo;

		protected override int SelectId(Todo entity) => entity.Id;

		protected override object SelectOrderKey(Todo entity)
			=> entity.BeginTime ?? entity.EndTime ?? DateTime.MinValue;
	}
}
