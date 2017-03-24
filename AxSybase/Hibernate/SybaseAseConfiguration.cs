using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;

namespace AxSybase.Hibernate
{
    public class SybaseAseConfiguration : PersistenceConfiguration<SybaseAseConfiguration, SybaseAseConnectionStringBuilder>
    {
        public static SybaseAseConfiguration SybaseAse15
        {
            get
            {
                return new SybaseAseConfiguration().Dialect<SybaseASE15Dialect>();
            }
        }

        protected SybaseAseConfiguration()
        {
            Driver<SybaseAdoNet4Driver>();
        }
    }
}
