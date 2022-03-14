using MySuperFilm.Repositories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class BasePageViewModel : BaseViewModel
    {
        public BasePageViewModel(
            IPublishedContent content,
            ContentRepository contentRepo)
            : base(content, contentRepo)
        {
            this.Name = content.Name;
        }

        public string Name { get; set; }
    }
}
