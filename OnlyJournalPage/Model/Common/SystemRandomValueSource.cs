using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Common
{
    public class SystemRandomValueSource : IRandomValueSource
    {
        private readonly Random random;

        public SystemRandomValueSource()
        {
            random = new Random();
        }

        public SystemRandomValueSource(Random random)
        {
            this.random = random;
        }

        public int Next() => random.Next();

        public double NextDouble() => random.NextDouble();
    }
}
