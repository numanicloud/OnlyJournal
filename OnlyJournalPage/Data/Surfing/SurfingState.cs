using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Data.Surfing
{
    [MessagePack.MessagePackObject]
    public class SurfingState
    {
        [Key(0)]
        public int GlobalProgress { get; set; } = 0;
        [Key(1)]
        public Dictionary<string, int> Progresses { get; } = new Dictionary<string, int>();
        [Key(2)]
        public Dictionary<string, int> RandomSeed { get; } = new Dictionary<string, int>();
    }
}
