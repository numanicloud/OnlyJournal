using Microsoft.Extensions.DependencyInjection;
using OnlyJournalPage.Model.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model
{
    public static class Helper
    {
        public static int GetRandomIndex(float[] densities, Random random = null)
        {
            var currentDensity = 0.0f;
            var rand = (float)random.NextDouble() * densities.Sum();
            for (int i = 0; i < densities.Length; i++)
            {
                if (currentDensity <= rand && rand < densities[i])
                {
                    return i;
                }
                currentDensity += densities[i];
            }
            return densities.Length - 1;
        }
    }
}
