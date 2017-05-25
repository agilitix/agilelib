using NHibernate.Driver;

namespace AxSybase.NHibernate
{
    public class SybaseAdoNet4Driver : ReflectionBasedDriver
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

        public SybaseAdoNet4Driver()
            : base("Sybase.AdoNet4.AseClient",
                   "Sybase.Data.AseClient.AseConnection",
                   "Sybase.Data.AseClient.AseCommand")
        {
        }
    }
}
