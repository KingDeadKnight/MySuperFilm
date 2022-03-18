namespace MySuperFilm.Controllers.Surface
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Umbraco.Cms.Core.Cache;
    using Umbraco.Cms.Core.Logging;
    using Umbraco.Cms.Core.Models.PublishedContent;
    using Umbraco.Cms.Core.Routing;
    using Umbraco.Cms.Core.Services;
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Infrastructure.Persistence;
    using Umbraco.Cms.Web.Website.Controllers;
    using Umbraco.Extensions;

    public class SeoReferencingController : SurfaceController
    {
        public ActionResult RobotsTxt()
        {
            var robotsTxts = this.UmbracoContext.Content.GetByXPath("//robotsTxt").ToList();
            string content = string.Empty;

            var defaultContent = "User-agent: *\r\nDisallow: /";
            var firstRobotsTxtFound = robotsTxts.FirstOrDefault();
            if (firstRobotsTxtFound.Value<bool>("disableIndexing"))
            {
                content += defaultContent;
            }
            else
            {
                content += firstRobotsTxtFound.Value<string>("content") ?? defaultContent;
                content += "\r\n";
                var sitemaps = robotsTxts.Select(r => r.Value<IPublishedContent>("sitemap"));
                content += string.Join("\r\n", sitemaps.Select(c => $"Sitemap: {c.Url(mode: UrlMode.Absolute)}")) + "\r\n";
            }

            return this.Content(content, "text/plain");
        }

        public SeoReferencingController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }
    }
}