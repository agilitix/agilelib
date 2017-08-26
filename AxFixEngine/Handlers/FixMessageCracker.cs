using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public abstract class FixMessageCracker
    {
        private readonly IDictionary<Type, Action<Message, SessionID>> _inboundActions = new Dictionary<Type, Action<Message, SessionID>>();
        private readonly IDictionary<Type, Action<Message, SessionID>> _outboundActions = new Dictionary<Type, Action<Message, SessionID>>();
        private readonly Action<Message, SessionID> _unsupportedMessageAction;

        protected FixMessageCracker()
            : this((m, s) => throw new UnsupportedMessageType())
        {
        }

        protected FixMessageCracker(Action<Message, SessionID> unsupportedMessageAction)
        {
            Initialize(this);
            _unsupportedMessageAction = unsupportedMessageAction;
        }

        public void CrackFrom(Message message, SessionID sessionID)
        {
            Crack(message, sessionID, _inboundActions);
        }

        public void CrackTo(Message message, SessionID sessionID)
        {
            Crack(message, sessionID, _outboundActions);
        }

        private void Initialize(FixMessageCracker messageCracker)
        {
            Type messageCrakerType = messageCracker.GetType();
            MethodInfo[] methodInfos = messageCrakerType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo methodInfo in methodInfos)
            {
                TryBuildCallCache(methodInfo, "OnMessageFrom", _inboundActions);
                TryBuildCallCache(methodInfo, "OnMessageTo", _outboundActions);
            }
        }

        private void TryBuildCallCache(MethodInfo methodInfo, string methodName, IDictionary<Type, Action<Message, SessionID>> handlers)
        {
            if (IsHandlerMethod(methodInfo, methodName))
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                ParameterInfo expParamMessage = parameters[0];
                ParameterInfo expParamSessionId = parameters[1];
                ParameterExpression messageParam = Expression.Parameter(typeof(Message), "message");
                ParameterExpression sessionParam = Expression.Parameter(typeof(SessionID), "sessionID");
                ConstantExpression instance = Expression.Constant(this);
                MethodCallExpression methodCall = Expression.Call(instance,
                                                                  methodInfo,
                                                                  Expression.Convert(messageParam, expParamMessage.ParameterType),
                                                                  Expression.Convert(sessionParam, expParamSessionId.ParameterType));
                Action<Message, SessionID> action = Expression.Lambda<Action<Message, SessionID>>(methodCall,
                                                                                                  messageParam,
                                                                                                  sessionParam).Compile();
                handlers[expParamMessage.ParameterType] = action;
            }
        }

        private static bool IsHandlerMethod(MethodInfo methodInfo, string methodName)
        {
            return methodInfo.IsPublic
                   && methodInfo.Name.Equals(methodName)
                   && methodInfo.GetParameters().Length == 2
                   && methodInfo.GetParameters()[0].ParameterType.IsSubclassOf(typeof(Message))
                   && typeof(SessionID).IsAssignableFrom(methodInfo.GetParameters()[1].ParameterType) && methodInfo.ReturnType == typeof(void);
        }

        private void Crack(Message message, SessionID sessionID, IDictionary<Type, Action<Message, SessionID>> actions)
        {
            Type type = message.GetType();
            Action<Message, SessionID> action;
            if (actions.TryGetValue(type, out action))
            {
                action(message, sessionID);
            }
            else
            {
                _unsupportedMessageAction?.Invoke(message, sessionID);
            }
        }
    }
}
