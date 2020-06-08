using MessagePack;
using Microsoft.Extensions.Hosting;
using OnlyJournalPage.Data.Surfing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.SaveData
{
    public class SaveDataRepository : ISaveDataRepository
    {
        private readonly IHostEnvironment env;
        private SurfingState surfingStateCache = null;
        private object lockObject = new object();

        public SaveDataRepository(IHostEnvironment env)
        {
            this.env = env;
        }

        public SurfingState GetSurfingState()
        {
            lock (lockObject)
            {
                if (surfingStateCache != null)
                {
                    return surfingStateCache;
                }
                // TODO: ファイル名をオプションに
                else if (!File.Exists("surfing.dat"))
                {
                    surfingStateCache = new SurfingState();
                }
                else
                {
                    var bytes = File.ReadAllBytes(Path.Combine(env.ContentRootPath, "surfing.dat"));
                    surfingStateCache = MessagePackSerializer.Deserialize<SurfingState>(bytes);
                    Debug.WriteLine("load: " + MessagePackSerializer.ConvertToJson(bytes));
                }

                return surfingStateCache;
            }
        }

        public void Save()
        {
            lock (lockObject)
            {
                if (surfingStateCache == null)
                {
                    GetSurfingState();
                }

                var bytes = MessagePackSerializer.Serialize<SurfingState>(surfingStateCache);
                File.WriteAllBytes(Path.Combine(env.ContentRootPath, "surfing.dat"), bytes);
                Debug.WriteLine("save: " + MessagePackSerializer.ConvertToJson(bytes));
            }
        }
    }
}
