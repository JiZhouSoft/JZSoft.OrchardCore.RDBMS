
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;

namespace JZSoft.OrchardCore.RDBMS.ViewModels
{
 
    public class RDBMSMappingConfigModel: ContentPart
    {
        public TextField ConfigName { get; set; }
        public string ContentTypeName { get; set; }
        public SyncMappingDeriction SyncMappingDeriction { get; set; }
        public string ConnectionConfigId { get; set; }
        public string TargetTable { get; set; }
        public DbObjectType DbObjectType { get; set; } 
        public string MappingData { get; set; }

        public bool ReadOnly { get; set; }

        public bool EnableAutoSync { get; set; }
    }

    public enum SyncMappingDeriction
    {
        OrchardCoreToRDBMS,
        RDBMSToOrchardCore,
        TwoWay

    }
    public enum DbObjectType
    {
        Table,
        View,
        SQLCommand
    }
}