using OnlyJournalPage.Data.Surfing;
using OnlyJournalPage.Model.SaveData;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    class MockSaveDataRepository : ISaveDataRepository
    {
        private SurfingState cache;

        public SurfingState GetSurfingState()
        {
            cache = cache ?? new SurfingState();
            return cache;
        }

        public void Save()
        {
        }
    }
}
