using OnlyJournal.Data.Habit;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data.Journal;
using OnlyJournalPage.Data.Todo;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockDataRepository<TRecord>
    {
        public IEnumerable<TRecord> Items { get; set; }
        public IEnumerable<TRecord> GetAll() => Items;
    }

    class MockHabitRepository : MockDataRepository<HabitRecord>, IHabitRecordRepository
    {
    }

    class MockJournalRepository : MockDataRepository<Journal>, IJournalRepository
    {
    }

    class MockTodoRepository : MockDataRepository<Todo>, ITodoRepository
    {
    }
}
