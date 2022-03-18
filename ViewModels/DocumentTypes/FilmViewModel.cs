using MySuperFilm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    using System.Collections;

    public class FilmViewModel : BaseViewModel
    {
        public FilmViewModel(
            IPublishedContent content,
            ContentRepository contentRepo)
            : base(content, contentRepo)
        {
            this.Duration = content.Value<int>("duration");
            this.PosterUrl = content.Value<IPublishedContent>("poster").GetCropUrl("poster");
            this.FilmUrl = content.Url();
            this.Title = content.Value<string>("title");
            this.Categories = content.Value<IEnumerable<string>>("categories");
            this.Synopsis = new HtmlEncodedString(content.Value<string>("synopsis"));
        }

        public string PosterUrl { get; set; }

        public string FilmUrl { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public int Duration { get; set; }

        public IHtmlEncodedString Synopsis { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
