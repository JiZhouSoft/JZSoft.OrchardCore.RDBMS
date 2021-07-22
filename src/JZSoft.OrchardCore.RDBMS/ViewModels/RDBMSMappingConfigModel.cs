using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZSoft.OrchardCore.RDBMS.ViewModels
{
    public class RDBMSMappingConfigModel
    {
        public string ConfigName { get; set; }
        public string ContentTypeName { get; set; }

        public string ConnectionConfigId { get; set; }
        public string TargetTable { get; set; }
        public DbObjectType DbObjectType { get; set; }

        public string MappingData { get; set; }

        public bool ReadOnly { get; set; }

        public bool EnableAutoSync { get; set; }

        public List<SelectListItem> AllContentTypes { get; set; }
        public List<SelectListItem> AllDbProviders { get; set; }

    }

    public enum DbObjectType
    {
        Table,
        View,
        SQLCommand
    }
}
