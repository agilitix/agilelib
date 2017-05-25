using NHibernate.Driver;

namespace AxSybase.NHibernate
{
    public class SybaseAdoNet45Driver : ReflectionBasedDriver
    {
        public override string NamedPrefix
        {
            get { return "@"; }
        }

        public override bool UseNamedPrefixInParameter
        {
            get { return true; }
        }

        public override bool UseNamedPrefixInSql
        {
            get { return true; }
        }

        public SybaseAdoNet45Driver()
            : base("Sybase.AdoNet45.AseClient",
                   "Sybase.Data.AseClient.AseConnection",
                   "Sybase.Data.AseClient.AseCommand")
        {
        }
    }
}
