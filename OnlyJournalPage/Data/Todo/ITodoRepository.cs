using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Todo
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
    }
}
