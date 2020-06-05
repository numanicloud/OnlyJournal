using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Options
{
    public class ArticleOption
    {
        public int JournalStaySeconds { get; set; } = 24;
        public int HabitStaySeconds { get; set; } = 12;
        public int TodoStaySeconds { get; set; } = 24;
        public int JournalWeight { get; set; } = 4;
        public int HabitWeight { get; set; } = 5;
        public int TodoWeight { get; set; } = 1;
    }
}
