namespace MySuperFilm
{
    using System;
    using System.IO;
    using Core;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MySuperFilm.Repositories;
    using Umbraco.Cms.Core.DependencyInjection;
    using Umbraco.Extensions;
    using Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Umbraco.Cms.Core.Services.Implement;
    using Umbraco.Cms.Infrastructure.PublishedCache;
    using Umbraco.Cms.Web.Common;

    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="webHostEnvironment">The web hosting environment.</param>
        /// <param name="config">The configuration.</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
#pragma warning disable IDE0022 // Use expression body for methods
            services.AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer(this._config.GetConnectionString("umbracoDbDSN"));
            services.AddScoped<DataContext>(_ => new DataContext(optionsBuilder.Options));
            services.AddTransient(typeof(ContentRepository));
            services.AddTransient(typeof(TestEditorRepository));
            services.AddTransient(typeof(CommentRepository));
            services.AddTransient(typeof(OmdbApiRepository));
            services.AddHttpClient();
            services.AddOptions<Settings>().Bind(this._config.GetSection("MySuperFilms"));
#pragma warning restore IDE0022 // Use expression body for methods

        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseUmbraco()
               .WithMiddleware(u =>
               {
                    u.UseBackOffice();
                    u.UseWebsite();
               })
               .WithEndpoints(u =>
               {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                    u.UseWebsiteEndpoints();
               });

            app.Use(async (context, next) =>
                    {
                        if (context.Request.Path.StartsWithSegments("/robots.txt"))
                        {
                            context.Response.Redirect("/umbraco/surface/SeoReferencing/robotsTxt");
                        }
                        else await next();
                    });
        }
    }
}
