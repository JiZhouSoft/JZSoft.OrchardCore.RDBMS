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
using JZSoft.OrchardCore.RDBMS.Services;
using JZSoft.OrchardCore.RDBMS.ViewModels;
using OrchardCore.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesSql;

namespace OrchardCore.RelationDb.Controllers
{
    public class AdminController : Controller
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
        private readonly IContentFieldsValuePathProvider _contentFieldsValuePathProvider;


        private readonly dynamic New;

        public AdminController(
            IAuthorizationService authorizationService,
            ISiteService siteService,
            IShapeFactory shapeFactory,
            IStringLocalizer<AdminController> stringLocalizer,
            IHtmlLocalizer<AdminController> htmlLocalizer,
            INotifier notifier,
            IUpdateModelAccessor updateModelAccessor,
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager, ISession session, IContentFieldsValuePathProvider contentFieldsValuePathProvider)
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
            _contentFieldsValuePathProvider = contentFieldsValuePathProvider;
        }

        public IActionResult CreateOrEdit()
        {
            // 1.拿到所有类型
            var allTypes = _contentDefinitionManager.ListTypeDefinitions();
            var items = allTypes.Select(x => new SelectListItem() { Text = S[x.DisplayName], Value = x.Name }).ToList();
            var model = new GenerateStartModel
            {
                AllTypes = items
            };
            return View(model);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetAllConnectionList()
        {
            var connectionSettings = await _session.Query<ContentItem, ContentItemIndex>()
                  .Where(x =>
                      x.ContentType == "DbConnectionConfig" &&
                      (x.Published || x.Latest)).ListAsync();
            return Json(connectionSettings);
        }

        public async Task<object> TryGetFileds()
        {
            var contentItems = await _session.Query<ContentItem, ContentItemIndex>()
                   .Where(x =>
                       x.ContentType == "RelationalDbMapping" &&
                       (x.Published || x.Latest)).ListAsync();

            return null;
        }



        public IActionResult GetFileds(string typeName)
        {
            var type = _contentDefinitionManager.LoadTypeDefinition(typeName);


            var part = type.Parts.FirstOrDefault(x => x.Name == type.Name);
            var partName = part.Name;
            var partFileds = new List<object>();
            // This builder only handles parts with fields.
            foreach (var field in part.PartDefinition.Fields)
            {
                var fieldType = _contentFieldsValuePathProvider.GetField(field);
                if (fieldType != null)
                {
                    partFileds.Add(new
                    {
                        name = field.Name,
                        ocPath = $"{type.Name}.{field.Name}.{fieldType.ValuePath}",
                        mapToTableFiled = field.Name
                    });
                }
            } 
            return Json(JArray.FromObject(partFileds).ToString());

        }

    }
}
