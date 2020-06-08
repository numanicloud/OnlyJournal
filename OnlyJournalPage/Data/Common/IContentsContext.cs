using OnlyJournal.Data.Habit;
using OnlyJournalPage.Data.Journal;
using OnlyJournalPage.Data.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Common
{
    public interface IContentsContext
    {
        IHabitRecordRepository Habits { get; }
        IJournalRepository Journals { get; }
        ITodoRepository Todos { get; }
    }
}
