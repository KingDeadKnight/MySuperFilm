using MySuperFilm.Repositories;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class BaseViewModel : ContentModel
    {
        public BaseViewModel(IPublishedContent content, ContentRepository contentRepo)
            : base(content)
        {
            this.MainMenuItems = contentRepo.GetMainMenu();
            this.FooterMenuItems = contentRepo.GetFooterMenu();
            this.MetaTitle = content.Value<string>("metaTitle", fallback: Fallback.ToAncestors);
            this.MetaDescription = content.Value<string>("metaDescription", fallback: Fallback.ToAncestors);
        }

        public IEnumerable<IPublishedContent> MainMenuItems { get; set;}

        public IEnumerable<IPublishedContent> FooterMenuItems { get; }

        public string MetaTitle { get; set;}

        public string MetaDescription { get; set; }
    }
}
