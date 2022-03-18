using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class FeaturedFilmViewModel
    {
        public FeaturedFilmViewModel(IPublishedContent content)
        {
            this.PosterUrl = content.Value<IPublishedContent>("poster").GetCropUrl("poster");
            this.FilmUrl = content.Url();
        }

        public string PosterUrl { get; set; }

        public string FilmUrl { get; set; }
    }
}
