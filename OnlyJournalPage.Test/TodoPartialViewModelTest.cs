using OnlyJournalPage.Data.Todo;
using OnlyJournalPage.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlyJournalPage.Test
{
	public class TodoPartialViewModelTest
	{
		[Theory]
		[InlineData(-45, +15, -10, +10, false)]
		[InlineData(-45, +15, -30, -20, true)]
		[InlineData(-40, -20, +10, +70, false)]
		[InlineData(-30, -20, -10, +90, false)]
		public void TODOの優先度を適切に決められる(int todo1Begin, int todo1End, int todo2Begin, int todo2End, bool isTodo1Win)
		{
			var subject = new TodoPartialViewModel(new MockContext());
			var now = DateTime.Now;


			var todo1 = new Todo()
			{
				Id = 0,
				Title = "Hoge",
				Description = "HogeHoge",
				PriorTimeBegin = now + new TimeSpan(0, todo1Begin, 0),
				PriorTimeEnd = now + new TimeSpan(0, todo1End, 0),
			};
			var priority1 = (double)subject.GetPriority(todo1);

			var todo2 = new Todo()
			{
				Id = 1,
				Title = "Fuga",
				Description = "FugaFuga",
				PriorTimeBegin = now + new TimeSpan(0, todo2Begin, 0),
				PriorTimeEnd = now + new TimeSpan(0, todo2End, 0),
			};
			var priority2 = (double)subject.GetPriority(todo2);

			Assert.True(priority1 >= priority2 == isTodo1Win);
		}

		[Fact]
		public void バグ調査1()
		{
			var subject = new TodoPartialViewModel(new MockContext());
			var now = DateTime.Now;


			var todo1 = new Todo()
			{
				Id = 0,
				Title = "Hoge",
				Description = "HogeHoge",
				PriorTimeBegin = new DateTime(2020, 6, 29, 6, 0, 0),
				PriorTimeEnd = new DateTime(2020, 6, 29, 14, 0, 0),
			};
			var priority1 = (double)subject.GetPriority(todo1);

			var todo2 = new Todo()
			{
				Id = 1,
				Title = "Fuga",
				Description = "FugaFuga",
				PriorTimeBegin = new DateTime(2020, 7, 1, 0, 0, 0),
				PriorTimeEnd = new DateTime(2020, 7, 1, 0, 30, 0),
			};
			var priority2 = (double)subject.GetPriority(todo2);

			var todo3 = new Todo()
			{
				Id = 1,
				Title = "Fuga",
				Description = "FugaFuga",
				PriorTimeBegin = new DateTime(2020, 7, 1, 1, 0, 0),
				PriorTimeEnd = new DateTime(2020, 7, 1, 1, 30, 0),
			};
			var priority3 = (double)subject.GetPriority(todo3);

			Assert.True(priority1 >= priority2);
			Assert.True(priority1 >= priority3);
			Assert.True(priority2 >= priority3);
		}
	}
}
