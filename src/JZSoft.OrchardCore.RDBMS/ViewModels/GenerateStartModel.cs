using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZSoft.OrchardCore.RDBMS.ViewModels
{
    public class GenerateStartModel
    {
        public string ConfigName { get; set; }
        public string TargetType { get; set; }

        public string ConnectionConfig { get; set; }
        public string TargetTable { get; set; }
        public List<SelectListItem> AllTypes { get; set; }
    }
}
