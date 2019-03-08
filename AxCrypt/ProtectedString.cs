using System;
using System.Security.Cryptography;
using System.Text;

namespace AxCrypt
{
    public class ProtectedString
    {
        protected readonly Encoding _encoding = Encoding.UTF8;
        protected readonly DataProtectionScope _protectionScope;

        public ProtectedString(DataProtectionScope protectionScope = DataProtectionScope.CurrentUser)
        {
            _protectionScope = protectionScope;
        }

        public string Protect(string unprotectedString)
        {
            byte[] unprotectedBytes = _encoding.GetBytes(unprotectedString);
            byte[] protectedBytes = ProtectedData.Protect(unprotectedBytes,
                                                          null /*entropy*/,
                                                          _protectionScope);
            return Convert.ToBase64String(protectedBytes);
        }

        public string Unprotect(string protectedString)
        {
            byte[] protectedBytes = Convert.FromBase64String(protectedString);
            byte[] unprotectedBytes = ProtectedData.Unprotect(protectedBytes,
                                                              null /*entropy*/,
                                                              _protectionScope);
            return _encoding.GetString(unprotectedBytes);
        }
    }
}
