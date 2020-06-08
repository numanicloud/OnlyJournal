using OnlyJournalPage.Data.Surfing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.SaveData
{
    public interface ISaveDataRepository
    {
        SurfingState GetSurfingState();
        void Save();
    }
}
