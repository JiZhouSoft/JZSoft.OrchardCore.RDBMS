using FreeSql;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                .UseMonitorCommand(executing =>
                {
                    executing.CommandTimeout = 6000;

                }, executed: (cmd, traceLog) =>
                {
                    var logStr = new StringBuilder();
                    if (cmd.Parameters.Count > 0)
                    {
                        logStr.AppendLine($"--Parameters: \r\ndeclare ");
                        var tempArray = new List<string>();
                        foreach (DbParameter item in cmd.Parameters)
                        {
                            tempArray.Add($"\t{item.ParameterName} {item.SourceColumn}='{item.Value}'");
                        }
                        logStr.AppendLine(string.Join(",\r\n", tempArray));
                    }

                    logStr.AppendLine($"\n{traceLog}\r\n");

                    var result = logStr.ToString();
                    Console.WriteLine(result);
                })
                            .Build(); 
            return freeSqlInstance;
        }
    }
}
