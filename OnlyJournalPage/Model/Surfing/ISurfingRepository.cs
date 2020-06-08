using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Surfing
{
    public interface ISurfingRepository
    {
        (string path, object queryString) GetNextPage();
    }
}
