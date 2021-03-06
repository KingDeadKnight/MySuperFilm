using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using MySuperFilm.ViewModels.DocumentTypes;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    public class FilmsController : BaseController
    {
        public FilmsController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor, contentRepository)
        {
        }

        public override IActionResult Index()
        {
            var filmsViewModel = new FilmsViewModel(CurrentPage, contentRepository);
            var search = this.HttpContext.Request.Query["search"];
            if(!string.IsNullOrEmpty(search))
            {

            }
            return CurrentTemplate(filmsViewModel);
        }
    }
}
