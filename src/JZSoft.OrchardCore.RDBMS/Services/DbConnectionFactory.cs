using OrchardCore.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;
using YesSql.Provider.MySql;
using YesSql.Provider.PostgreSql;
using YesSql.Provider.Sqlite;
using YesSql.Provider.SqlServer;

namespace JZSoft.OrchardCore.RDBMS.Services
{
    public class DbConnectionFactory
    {
        public static IStore GetYessqlStore(DatabaseProvider databaseProvider)
        { 
            IConfiguration storeConfiguration = new YesSql.Configuration();
            switch (databaseProvider.Value)
            {
                case "SqlConnection":
                    storeConfiguration
                        .UseSqlServer(databaseProvider.SampleConnectionString, IsolationLevel.ReadUncommitted)
                        .UseBlockIdGenerator();
                    break;
                case "Sqlite": 
                    storeConfiguration
                        .UseSqLite($"Data Source={databaseProvider.SampleConnectionString};Cache=Shared", IsolationLevel.ReadUncommitted)
                        .UseDefaultIdGenerator();
                    break;
                case "MySql":
                    storeConfiguration
                        .UseMySql(databaseProvider.SampleConnectionString, IsolationLevel.ReadUncommitted)
                        .UseBlockIdGenerator();
                    break;
                case "Postgres":
                    storeConfiguration
                        .UsePostgreSql(databaseProvider.SampleConnectionString, IsolationLevel.ReadUncommitted)
                        .UseBlockIdGenerator();
                    break;
                default:
                    throw new ArgumentException("Unknown database provider  ");
            }
            var store = StoreFactory.CreateAndInitializeAsync(storeConfiguration).GetAwaiter().GetResult();
            return store;
        }
    }
}
