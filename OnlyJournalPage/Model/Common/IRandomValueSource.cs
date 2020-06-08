using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Common
{
    public interface IRandomValueSource
    {
        int Next();
        double NextDouble();
    }

    public static class RandomValueSourceExtension
    {
        public static int Next(this IRandomValueSource source, int minInclude, int maxInclude)
        {
            if (minInclude > maxInclude)
                Swap(ref minInclude, ref maxInclude);
            return source.Next() % (maxInclude - minInclude) + minInclude;
        }

        public static double NextDouble(this IRandomValueSource source, double minInclude, double maxExclude)
        {
            if (minInclude > maxExclude)
            {
                Swap(ref minInclude, ref maxExclude);
            }
            return source.NextDouble() * (maxExclude - minInclude) + minInclude;
        }

        public static float NextFloat(this IRandomValueSource source, float minInclude, float maxExclude)
        {
            if (minInclude > maxExclude)
            {
                Swap(ref minInclude, ref maxExclude);
            }
            return (float)source.NextDouble() * (maxExclude - minInclude) + minInclude;
        }

        public static void Swap<T>(ref T x, ref T y)
        {
            T work = x;
            y = x;
            x = work;
        }
    }
}
