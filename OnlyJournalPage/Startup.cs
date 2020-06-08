using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OnlyJournalPage.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using OnlyJournalPage.Model.Article;

using static Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders;
using OnlyJournalPage.Model.Options;
using OnlyJournalPage.Model.Surfing;
using OnlyJournalPage.Model.Journals;
using OnlyJournalPage.Model.Habits;
using OnlyJournalPage.Model.Todos;

namespace OnlyJournalPage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            /*/
		    services.AddDbContext<OnlyJournalContext>(options =>
		            options.UseSqlServer(Configuration.GetConnectionString("OnlyJournalContext")));
			//*/
            services.AddDbContext<OnlyJournalContext>();

            services.AddSingleton<ArticleRepository>();
            services.Configure<ArticleOption>(Configuration);

            services.AddSingleton<ISurfingRepository, SurfingRepository>();
            services.AddSingleton<IArticleRepository, DailyJournalArticleRepository>();
            services.AddSingleton<IArticleRepository, HonorJournalArticleRepository>();
            services.AddSingleton<IArticleRepository, TechJournalArticleRepository>();
            services.AddSingleton<IArticleRepository, GeneralHabitArticleRepository>();
            services.AddSingleton<IArticleRepository, HabitListArticleRepository>();
            services.AddSingleton<IArticleRepository, CompletedHabitArticleRepository>();
            services.AddSingleton<IArticleRepository, TodoArticleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = XForwardedFor | XForwardedProto
            });

            app.UseAuthentication();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
