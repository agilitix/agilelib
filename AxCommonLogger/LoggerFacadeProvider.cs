using System;
using System.Diagnostics;
using System.Reflection;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger
{
    public static class LoggerFacadeProvider
    {
        private static ILoggerFacadeFactory _LoggerFacadeFactory;

        public static void Initialize(ILoggerFacadeFactory loggerFacadeFactory)
        {
            _LoggerFacadeFactory = loggerFacadeFactory;
        }

        public static ILoggerFacade GetDeclaringClassLogger()
        {
            int skipFrames = 1;
            string declaringClassName;

            while (true)
            {
                StackFrame stackFrame = new StackFrame(skipFrames++, false);

                MethodBase method = stackFrame.GetMethod();
                Type declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    declaringClassName = method.Name;
                    break;
                }

                declaringClassName = declaringType.FullName;
                if (!declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            return _LoggerFacadeFactory.GetLogger(declaringClassName);
        }


        public static ILoggerFacade GetLogger<T>()
        {
            return _LoggerFacadeFactory.GetLogger<T>();
        }
    }
}
