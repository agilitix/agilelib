using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixConnectionFactory
    {
        IFixConnection CreateAcceptor(IFixApplication fixApplication, string acceptorConfigFile);
        IFixConnection CreateInitiator(IFixApplication fixApplication, string initiatorConfigFile);
    }
}
