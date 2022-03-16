using MySuperFilm.Repositories;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace MySuperFilm.ViewModels.DocumentTypes
{
    public class IntroViewModel : BaseViewModel
    {
        public IntroViewModel(IPublishedContent content, ContentRepository contentRepository) : base(content, contentRepository)
        {
            this.Value1 = content.Value<string>("value1");
            this.Value2Url = content.Value<IPublishedContent>("value2").Url();
            this.Value3Url = content.Value<IPublishedContent>("value3").Url();
        }

        public string Value1 { get; set; }
        public string Value2Url { get; set; }
        public string Value3Url { get; set; }
    }
}
