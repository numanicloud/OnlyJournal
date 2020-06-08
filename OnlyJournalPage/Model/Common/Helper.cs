using Microsoft.Extensions.DependencyInjection;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model
{
    public static class Helper
    {
        public static int GetRandomIndex(float[] densities, IRandomValueSource random)
        {
            var currentDensity = 0.0f;
            var rand = random.NextFloat(0, densities.Sum());
            Debug.WriteLine($"random: {densities[0]}, {densities[1]}, {densities[2]}; {rand}");
            for (int i = 0; i < densities.Length; i++)
            {
                Debug.WriteLine($"{currentDensity} <= {rand} < {currentDensity + densities[i]}");
                if (currentDensity <= rand && rand < currentDensity + densities[i])
                {
                    Debug.WriteLine($"result: {i}");
                    return i;
                }
                currentDensity += densities[i];
            }
            return densities.Length - 1;
        }

        public static IServiceCollection AddArticleRepo<T>(this IServiceCollection services)
            where T : class, IArticleRepository
        {
            return services.AddScoped<IArticleRepository, T>()
                .AddScoped<T>();
        }
    }
}
