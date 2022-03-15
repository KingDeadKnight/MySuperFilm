using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using MySuperFilm.ViewModels.DocumentTypes;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    public class BasePageController : BaseController
    {
        public BasePageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor, contentRepository)
        {
        }

        public override IActionResult Index()
        {
            return CurrentTemplate(new BasePageViewModel(CurrentPage, contentRepository));
        }
    }
}
