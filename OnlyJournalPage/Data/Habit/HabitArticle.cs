using OnlyJournal.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournal.Data.Habit
{
	public class HabitArticle : IArticle
	{
		public string LinkName => "/Habit";
		public string Key { get; }
		public int Priority { get; set; } = 0;

		public HabitArticle(string key)
		{
			Key = key;
		}

		public void OnShown()
		{
			Priority += -1;
		}
	}
}
