namespace MySuperFilm.Controllers.Api
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Repositories;
    using Umbraco.Cms.Web.Common.Controllers;
    using ViewModels.Api;

    public class BackofficeApiController : UmbracoApiController
    {
        private readonly TestEditorRepository _testEditorRepository;

        public BackofficeApiController(TestEditorRepository testEditorRepository)
        {
            _testEditorRepository = testEditorRepository;
        }

        // umbraco/api/Backofficeapi/GetAll
        public IEnumerable<TestEditorViewModel> GetAll()
            => this._testEditorRepository
                   .GetAll().Select(c => new TestEditorViewModel
                                         {
                                             Id = c.Id,
                                             Value = c.Value
                                         });
    }
}