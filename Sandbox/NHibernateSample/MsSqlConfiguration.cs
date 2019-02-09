using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace nhibertest
{
    public class MsSqlConfiguration : Configuration
    {
        public MsSqlConfiguration(string connectionString)
        {
            this.DataBaseIntegration(di =>
                                     {
                                         di.ConnectionString = connectionString;
                                         di.Driver<Sql2008ClientDriver>();
                                         di.Dialect<MsSql2012Dialect>();
                                         di.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                                         di.LogFormattedSql = true;
                                         di.LogSqlInConsole = true;
                                     });
        }
    }
}
