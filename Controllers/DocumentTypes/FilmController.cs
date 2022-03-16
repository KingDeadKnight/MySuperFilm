using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using MySuperFilm.ViewModels.DocumentTypes;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    public class FilmController : BaseController
    {
        private readonly OmdbApiRepository omdbApiRepository;

        public FilmController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository,
            OmdbApiRepository omdbApiRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor, contentRepository)
        {
            this.omdbApiRepository = omdbApiRepository;
        }

        public override IActionResult Index()
        {
            var film = new FilmViewModel(CurrentPage, contentRepository);
            var filmFromApi = this.omdbApiRepository.GetFilm(film.Title).Result;
            film.Rated = filmFromApi.Rated;
            film.Released = filmFromApi.Released;
            return this.CurrentTemplate(film);
        }
    }
}
