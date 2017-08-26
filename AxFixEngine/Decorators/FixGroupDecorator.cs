using System;
using QuickFix;

namespace AxFixEngine.Decorators
{
    public abstract class FixGroupDecorator : Group
    {
        private readonly Group _group;

        protected FixGroupDecorator(Group group)
            : base(group)
        {
            _group = group;
        }

        public void Accept(Action<Group> visitor)
        {
            visitor?.Invoke(_group);
        }

        public override string ToString()
        {
            return _group.ToString();
        }

        protected T DecoratedGroup<T>() where T : Group
        {
            return (T) _group;
        }
    }
}
