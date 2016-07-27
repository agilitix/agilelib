using System;

namespace AxUtils
{
    public sealed class DisposableAction : IDisposable
    {
        private readonly Action _action;

        public DisposableAction(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}