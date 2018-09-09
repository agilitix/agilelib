using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Factories
{
    public abstract class LoggerFacadeFactoryBase : ILoggerFacadeFactory
    {
        public abstract void Configure(string loggerConfigurationFile);
        public abstract ILoggerFacade GetLogger<T>();
        public abstract ILoggerFacade GetLogger(string loggerName);
        public abstract ILoggerFacade GetDeclaringTypeLogger();

        protected Type GetDeclaringType()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            Type declaringType = null;

            StackTrace stackTrace = new StackTrace();
            for (int i = 2; i < stackTrace.FrameCount; ++i)
            {
                var frame = new StackFrame(i, false);
                declaringType = frame.GetMethod().DeclaringType;
                if (declaringType?.Assembly != thisAssembly)
                {
                    break;
                }
            }

            return declaringType ?? GetType();
        }
    }
}
