using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class FilmLiteViewModel
    {
        public FilmLiteViewModel(IPublishedContent content)
        {
            this.PosterUrl = content.Value<IPublishedContent>("poster").GetCropUrl("poster");
            this.FilmUrl = content.Url();
            this.Title = content.Value<string>("title");
            this.Categories = content.Value<IEnumerable<string>>("categories");
        }

        public string PosterUrl { get; set; }

        public string FilmUrl { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Categories { get; set;}
    }
}
