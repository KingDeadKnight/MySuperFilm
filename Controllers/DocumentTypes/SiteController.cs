namespace MySuperFilm.Controllers.DocumentTypes
{
    using System.Linq;
    using Core;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Web.Common.Controllers;

    public class SiteController : RenderController
    {
        public SiteController(ILogger<RenderController> logger,
                              ICompositeViewEngine compositeViewEngine,
                              IUmbracoContextAccessor umbracoContextAccessor,
                              IOptions<Settings> settings)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            this.settings = settings;
        }

        private readonly IOptions<Settings> settings;

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language
        {
            get
            {
                if (this.Request.Headers["Accept-Language"].ToString() == null || this.Request.Headers["Accept-Language"].ToString().Length < 2)
                {
                    return this.settings.Value.DefaultLanguage;
                }

                var language = this.Request.Headers["Accept-Language"].ToString().Substring(0, 2);
                if (!this.settings.Value.AvailableLanguages.Contains(language))
                {
                    language = this.settings.Value.DefaultLanguage;
                }

                return language;
            }
        }

        public override IActionResult Index()
        {
            if (this.Request.Path == "/")
            {
                return this.RedirectPermanent($"/{this.Language}");
            }
            return this.CurrentTemplate(CurrentPage);
        }
    }
}