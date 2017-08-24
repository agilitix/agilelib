using QuickFix;

namespace AxFixEngine.Decorators
{
    public class FixGroupDecorator : Group
    {
        private readonly Group _group;

        public FixGroupDecorator(Group group)
            : base(group)
        {
            _group = group;
        }

        public override string ToString()
        {
            return _group.ToString();
        }

        public T Decorated<T>() where T : Group
        {
            return (T) _group;
        }
    }
}
