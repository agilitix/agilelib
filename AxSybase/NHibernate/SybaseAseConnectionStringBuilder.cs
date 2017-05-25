using System.Text;

namespace AxSybase.NHibernate
{
    public class SybaseAseConnectionStringBuilder
    {
        // Please look there for several connection string samples.
        // Feel free to customise this class with new parameters.
        // https://www.connectionstrings.com/ase-ado-net-data-provider/
        //
        // Look there for the charset value. You must setup the
        // charset like in the ASE server if you got an exception
        // "Unsupported Charset" at OpenSession.
        // https://www.connectionstrings.com/ase-unsupported-charset/

        private string _server;
        private int _port;
        private string _database;
        private string _username;
        private string _password;
        private string _charset; // "iso_1", "utf8", etc...

        public static SybaseAseConnectionStringBuilder ConnectionString
        {
            get { return new SybaseAseConnectionStringBuilder(); }
        }

        public SybaseAseConnectionStringBuilder Server(string server)
        {
            _server = server;
            return this;
        }

        public SybaseAseConnectionStringBuilder Port(int port)
        {
            _port = port;
            return this;
        }

        public SybaseAseConnectionStringBuilder Database(string database)
        {
            _database = database;
            return this;
        }

        public SybaseAseConnectionStringBuilder Username(string username)
        {
            _username = username;
            return this;
        }

        public SybaseAseConnectionStringBuilder Password(string password)
        {
            _password = password;
            return this;
        }

        public SybaseAseConnectionStringBuilder Charset(string charset)
        {
            _charset = charset;
            return this;
        }

        public string Build()
        {
            StringBuilder connectionStringBuilder = new StringBuilder();

            connectionStringBuilder.AppendFormat("Data Source={0};Port={1};Database={2};Uid={3};Pwd={4}",
                                                 _server,
                                                 _port,
                                                 _database,
                                                 _username,
                                                 _password);

            if (!string.IsNullOrWhiteSpace(_charset))
            {
                connectionStringBuilder.AppendFormat(";Charset={0}", _charset);
            }

            return connectionStringBuilder.ToString();
        }
    }
}
