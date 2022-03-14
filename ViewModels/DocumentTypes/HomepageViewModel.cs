using MySuperFilm.Repositories;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class HomepageViewModel : BaseViewModel
    {
        public HomepageViewModel(IPublishedContent content, ContentRepository contentRepo) 
            : base(content, contentRepo)
        {
            this.FeaturedFilms = content.DescendantsOfType("film")
                                        .OrderByDescending(f => f.CreateDate)
                                        .Take(3)
                                        .Select(f => new FeaturedFilmViewModel(f));
            this.HeaderTitle = content.Value<string>("headerTitle");
            this.HeaderSubtitle = content.Value<string>("headerSubtitle");
        }

        public IEnumerable<FeaturedFilmViewModel> FeaturedFilms { get; set; }

        public string HeaderTitle { get; set; }

        public string HeaderSubtitle { get; set; }
    }
}
