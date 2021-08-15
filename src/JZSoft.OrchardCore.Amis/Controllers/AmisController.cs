using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesSql;
using OrchardCore.ContentManagement.Metadata.Records;

namespace OrchardCore.RelationDb.Controllers
{
    public class AmisController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;
        private readonly ISiteService _siteService;
        private readonly INotifier _notifier;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        private readonly IStringLocalizer S;
        private readonly IHtmlLocalizer H;
        private readonly ISession _session;


        private readonly dynamic New;

        public AmisController(
            IAuthorizationService authorizationService,
            ISiteService siteService,
            IShapeFactory shapeFactory,
            IStringLocalizer<AmisController> stringLocalizer,
            IHtmlLocalizer<AmisController> htmlLocalizer,
            INotifier notifier,
            IUpdateModelAccessor updateModelAccessor,
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager, ISession session )
        {
            _authorizationService = authorizationService;
            _siteService = siteService;
            _updateModelAccessor = updateModelAccessor;
            New = shapeFactory;
            _notifier = notifier;
            S = stringLocalizer;
            H = htmlLocalizer;
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("JZSoft.OrchardCore.Amis/amis-editor/index")]
        [AllowAnonymous]
        public IActionResult Editor()
        {
            return View();
        }

    }
}
