using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    public class BaseController : RenderController
    {
        protected readonly ContentRepository contentRepository;

        public BaseController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            this.contentRepository = contentRepository;
        }
    }
}
