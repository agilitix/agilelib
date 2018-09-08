using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;

namespace AxSybase.NHibernate.Fluent
{
    public class SybaseFluentPersistenceConfiguration : PersistenceConfiguration<SybaseFluentPersistenceConfiguration>
    {
        public static SybaseFluentPersistenceConfiguration SybaseAse15 => new SybaseFluentPersistenceConfiguration().Dialect<SybaseASE15Dialect>();

        protected SybaseFluentPersistenceConfiguration()
        {
            Driver<SybaseAdoNet4Driver>();
        }
    }
}
