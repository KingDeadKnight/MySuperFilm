using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using MySuperFilm.Repositories;
using MySuperFilm.ViewModels.DocumentTypes;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MySuperFilm.Controllers.DocumentTypes
{
    using System.Linq;
    using Umbraco.Cms.Core.Security;
    using Umbraco.Cms.Core.Services;

    public class FilmController : BaseController
    {
        private readonly OmdbApiRepository omdbApiRepository;
        private readonly IMemberService _memberService;
        private readonly CommentRepository commentRepository;

        public FilmController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ContentRepository contentRepository,
            OmdbApiRepository omdbApiRepository,
            IMemberService memberService,
            CommentRepository commentRepository)
            : base(logger, compositeViewEngine, umbracoContextAccessor, contentRepository)
        {
            this.omdbApiRepository = omdbApiRepository;
            _memberService = memberService;
            this.commentRepository = commentRepository;
        }

        public override IActionResult Index()
        {
            var film = new FilmViewModel(CurrentPage, contentRepository);
            var filmFromApi = this.omdbApiRepository.GetFilm(film.Title).Result;
            film.Rated = filmFromApi.Rated;
            film.Released = filmFromApi.Released;
            //film.Comments = this.commentRepository.GetCommentsByFilm(film.Content.Id);
            film.Comments = this.commentRepository
                                .GetCommentsByFilm(CurrentPage.Id)
                                .Select(c => new CommentViewModel()
                                             {
                                                 Username = c.MemberId.HasValue
                                                                ? $"{this._memberService.GetById(c.MemberId.Value).Username} {this._memberService.GetById(c.MemberId.Value).GetValue<int>("age")}"
                                                                : "Anonyme",
                                                 Text = c.Text,
                                                 CreatedDate = c.CreatedDate
                                             });
            return this.CurrentTemplate(film);
        }
    }
}
