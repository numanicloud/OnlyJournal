using OnlyJournal.Data.Habit;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data.Common;
using OnlyJournalPage.Data.Journal;
using OnlyJournalPage.Data.Todo;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockContext : IContentsContext
    {
        public IHabitRecordRepository Habits => new MockHabitRepository
        {
            Items = new HabitRecord[0]
        };

        public IJournalRepository Journals => new MockJournalRepository
        {
            Items = new Journal[]
            {
                new Journal { Id = 0 },
                new Journal { Id = 1 },
                new Journal { Id = 2 },
                new Journal { Id = 3 },
                new Journal { Id = 4 },
            }
        };

        public ITodoRepository Todos => new MockTodoRepository
        {
            Items = new Todo[0]
        };
    }
}
