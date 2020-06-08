using Microsoft.Extensions.DependencyInjection;
using OnlyJournalPage.Model.Article;
using OnlyJournalPage.Model.Common;
using System;
using System.Collections.Generic;
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

        public static IServiceCollection AddArticleRepo<T>(this IServiceCollection services)
            where T : class, IArticleRepository
        {
            return services.AddScoped<IArticleRepository, T>()
                .AddScoped<T>();
        }
    }
}
