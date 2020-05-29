using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;

namespace OnlyJournalMvc.Data
{
    public class OnlyJournalMvcContext : DbContext
    {
        public OnlyJournalMvcContext (DbContextOptions<OnlyJournalMvcContext> options)
            : base(options)
        {
        }

        public DbSet<OnlyJournal.Data.Journal.Journal> Journal { get; set; }
    }
}
