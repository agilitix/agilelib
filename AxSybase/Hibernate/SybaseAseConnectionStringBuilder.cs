using System.Text;
using FluentNHibernate.Cfg.Db;

namespace AxSybase.Hibernate
{
    public class SybaseAseConnectionStringBuilder : ConnectionStringBuilder
    {
        private string _server;
        private int _port;
        private string _username;
        private string _password;
        private string _database;
        private string _charset;

        public SybaseAseConnectionStringBuilder Server(string server)
        {
            _server = server;
            IsDirty = true;
            return this;
        }

        public SybaseAseConnectionStringBuilder Port(int port)
        {
            _port = port;
            IsDirty = true;
            return this;
        }

        public SybaseAseConnectionStringBuilder Database(string database)
        {
            _database = database;
            IsDirty = true;
            return this;
        }

        public SybaseAseConnectionStringBuilder Username(string username)
        {
            _username = username;
            IsDirty = true;
            return this;
        }

        public SybaseAseConnectionStringBuilder Password(string password)
        {
            _password = password;
            IsDirty = true;
            return this;
        }

        public SybaseAseConnectionStringBuilder Charset(string charset)
        {
            _charset = charset;
            IsDirty = true;
            return this;
        }

        protected override string Create()
        {
            string str = base.Create();

            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Uid='{0}';Pwd='{1}';Data Source='{2}';Port='{3}';Database='{4}'", _username, _password, _server, _port, _database);
            if (!string.IsNullOrWhiteSpace(_charset))
            {
                stringBuilder.AppendFormat(";Charset='{0}'", _charset);
            }

            return stringBuilder.ToString();
        }
    }
}
