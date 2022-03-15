using MySuperFilm.Repositories;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class FilmsViewModel : BaseViewModel
    {
        public FilmsViewModel(
            IPublishedContent content,
            ContentRepository contentRepo)
            : base(content, contentRepo)
        {
            this.Films = content.ChildrenOfType("film").OrderByDescending(f => f.CreateDate).Select(f => new FilmLiteViewModel(f));

            this.HeaderTitle = content.Value<string>("headerTitle");
            this.HeaderSubtitle = content.Value<string>("headerSubtitle");
        }

        public IEnumerable<FilmLiteViewModel> Films { get; set; }

        public string HeaderTitle { get; set; }

        public string HeaderSubtitle { get; set; }
    }
}
