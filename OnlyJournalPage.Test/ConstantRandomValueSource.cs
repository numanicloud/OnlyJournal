using OnlyJournalPage.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyJournalPage.Test
{
    public class ConstantRandomValueSource : IRandomValueSource
    {
        private int nextInt = 0;
        private double nextDouble = 0;

        public ConstantRandomValueSource(int baseValue)
        {
            nextInt = baseValue;
            nextDouble = baseValue;
        }

        public int Next()
        {
            return nextInt++;
        }

        public double NextDouble()
        {
            nextDouble = (nextDouble + 0.1) % 1;
            return nextDouble;
        }
    }
}
