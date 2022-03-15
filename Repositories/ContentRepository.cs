using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace MySuperFilm.Repositories
{
    public class ContentRepository
    {
        private readonly UmbracoHelper umbracoHelper;

        public ContentRepository(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }

        public IEnumerable<IPublishedContent> GetMainMenu()
            => this.umbracoHelper.ContentSingleAtXPath("/root/homepage")
                                 .Children()
                                 .Where(p => p.Value<bool>("mainMenu"));

        public IEnumerable<IPublishedContent> GetFooterMenu()
            => this.umbracoHelper.ContentSingleAtXPath("/root/homepage")
                                 .Children()
                                 .Where(p => p.Value<bool>("footerMenu"));
    }
}
