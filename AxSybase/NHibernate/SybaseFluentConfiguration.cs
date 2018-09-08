using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace AxSybase.NHibernate.Fluent
{
    public class SybaseFluentConfiguration
    {
        protected FluentConfiguration _fluentConfiguration;
        protected string _connectionString;

        public SybaseFluentConfiguration(string connectionString)
        {
            _connectionString = connectionString;
            _fluentConfiguration = Fluently.Configure()
                                           .Database(SybaseFluentPersistenceConfiguration.SybaseAse15
                                                                                         .ConnectionString(connectionString)
                                                                                         .ShowSql());
        }

        public void AddMappings(Type[] mappingTypes)
        {
            foreach (Type mapping in mappingTypes)
            {
                _fluentConfiguration.Mappings(m => m.FluentMappings.Add(mapping));
            }
        }

        public void AddMappingsFromAssembly(Assembly assembly)
        {
            _fluentConfiguration.Mappings(m => m.FluentMappings.AddFromAssembly(assembly));
        }

        public Configuration BuildConfiguration()
        {
            return _fluentConfiguration.BuildConfiguration();
        }

        public ISessionFactory BuildSessionFactory()
        {
            return _fluentConfiguration.BuildSessionFactory();
        }
    }
}
