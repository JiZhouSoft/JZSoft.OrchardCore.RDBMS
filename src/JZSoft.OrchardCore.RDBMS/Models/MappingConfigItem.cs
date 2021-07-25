using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZSoft.OrchardCore.RDBMS.Models
{
    public class MappingConfigItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string OCFieldType { get; set; }
        public string ValuePath { get; set; }
        public string DbField { get; set; }
    }
}
