using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using MySuperFilm.ViewModels.DocumentTypes;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    public class HomepageController : BaseController
    {
        public HomepageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor, contentRepository)
        {
        }

        public override IActionResult Index()
        {
            return this.CurrentTemplate(new HomepageViewModel(CurrentPage, contentRepository));
            //return this.Homepage2();
        }

        public IActionResult Homepage2()
        {
            return this.CurrentTemplate(CurrentPage);
        }
    }
}
