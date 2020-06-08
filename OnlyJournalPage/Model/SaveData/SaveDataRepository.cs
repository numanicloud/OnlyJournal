using MessagePack;
using Microsoft.Extensions.Hosting;
using OnlyJournalPage.Data.Surfing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.SaveData
{
    public class SaveDataRepository : ISaveDataRepository
    {
        private readonly IHostEnvironment env;
        private SurfingState surfingStateCache = null;

        public SaveDataRepository(IHostEnvironment env)
        {
            this.env = env;
        }

        public SurfingState GetSurfingState()
        {
            using var file = File.OpenRead(Path.Combine(env.ContentRootPath, "surfing.dat"));
            var state = MessagePackSerializer.Deserialize<SurfingState>(file);
            surfingStateCache = state;
            return state;
        }

        public void Save()
        {
            using var file = File.OpenWrite(Path.Combine(env.ContentRootPath, "surfing.dat"));
            MessagePackSerializer.Serialize<SurfingState>(file, surfingStateCache);
        }
    }
}
