using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZSoft.OrchardCore.RDBMS.Services
{
    public class FreeSqlProviderFactory
    {
        public static IFreeSql GetFreeSql(string providerName, string connectionString)
        {
            //按照需要添加其他数据库的引用
            DataType freeSqlDataType = Enum.Parse<DataType>(providerName);

            var freeSqlInstance = new FreeSqlBuilder().UseConnectionString(freeSqlDataType, connectionString)
                            .Build(); 
            return freeSqlInstance;
        }
    }
}
