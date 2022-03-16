namespace MySuperFilm.Controllers.Surface
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Repositories;
    using Umbraco.Cms.Core.Cache;
    using Umbraco.Cms.Core.Logging;
    using Umbraco.Cms.Core.Routing;
    using Umbraco.Cms.Core.Security;
    using Umbraco.Cms.Core.Services;
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Infrastructure.Persistence;
    using Umbraco.Cms.Web.Common.Filters;
    using Umbraco.Cms.Web.Website.Controllers;
    using ViewModels.Surface;

    public class CommentsSurfaceController : SurfaceController
    {
        private readonly CommentRepository _commentRepository;
        private readonly IMemberService _memberService;
        private readonly IMemberManager _memberManager;

        public CommentsSurfaceController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            CommentRepository commentRepository,
            IMemberService memberService,
            IMemberManager memberManager)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _commentRepository = commentRepository;
            _memberService = memberService;
            _memberManager = memberManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUmbracoFormRouteString]
        public async Task<IActionResult> SubmitCommentAsync([Bind(Prefix = "commentModel")]CreateCommentModel createCommentModel)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            createCommentModel.MemberId = int.Parse((await this._memberManager.GetCurrentMemberAsync()).Id);
            /*
             new Data.Models.Comment {

                FilmNodeId = this.CurrentPage.Id
             }
             */

            await this._commentRepository.CreateAsync(createCommentModel);
            return RedirectToCurrentUmbracoPage(new QueryString("?success=true"));
        }
    }
}