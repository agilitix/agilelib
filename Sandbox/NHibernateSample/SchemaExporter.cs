using System.IO;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace nhibertest
{
    public class SchemaExporter
    {
        protected SchemaExport _schemaExport;

        public SchemaExporter(global::NHibernate.Cfg.Configuration configuration)
        {
            _schemaExport = new SchemaExport(configuration);
        }

        public void ToFile(string fileName)
        {
            _schemaExport.SetOutputFile(fileName).Execute(false /*stdout*/,
                                                          false /*execute*/,
                                                          false /*just drop*/);
        }

        public void ToConsole()
        {
            _schemaExport.Execute(true /*stdout*/,
                                  false /*execute*/,
                                  false /*just drop*/);
        }

        public string ToText()
        {
            StringWriter sw = new StringWriter();
            _schemaExport.Execute(str => { },
                                  false /*execute*/,
                                  false /*just drop*/,
                                  sw);
            return sw.ToString();
        }

        public string ToDatabase(ISession session)
        {
            StringWriter sw = new StringWriter();
            _schemaExport.Execute(false /*stdout*/,
                                  true /*execute*/,
                                  false /*just drop*/,
                                  session.Connection,
                                  sw);
            return sw.ToString();
        }
    }
}
