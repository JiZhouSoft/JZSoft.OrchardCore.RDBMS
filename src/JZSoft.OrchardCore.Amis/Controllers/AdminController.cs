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
    public class AdminController : Controller
    {
 
 

        public IActionResult Index()
        {
            return View();
        }
        [Route("JZSoft.OrchardCore.Amis/amis-editor/index")]
        [AllowAnonymous]
        public IActionResult AmisEditor()
        {
            return Redirect("~/JZSoft.OrchardCore.Amis/amis-editor/index.html");
            //return View();
        }

    }
}
