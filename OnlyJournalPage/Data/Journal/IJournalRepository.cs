using OnlyJournal.Data.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Journal
{
    public interface IJournalRepository
    {
        IEnumerable<OnlyJournal.Data.Journal.Journal> GetAll();
    }
}
