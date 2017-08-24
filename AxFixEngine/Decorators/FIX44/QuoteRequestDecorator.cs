using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;

namespace AxFixEngine.Decorators.FIX44
{
    /// <summary>
    /// Example of use :
    /// 
    /// QuoteRequestDecorator quoteRequest = new QuoteRequestDecorator(new QuoteRequest());
    /// 
    /// NoRelatedSymGroupDecorator noRelatedSymGroup = new NoRelatedSymGroupDecorator(new QuoteRequest.NoRelatedSymGroup());
    /// noRelatedSymGroup.Symbol = new Symbol("VOD.L");
    /// ......
    /// 
    /// quoteRequest.AddNoRelatedSymGroup(no);
    /// </summary>
    public class QuoteRequestDecorator : FixMessageDecorator
    {
        public QuoteRequestDecorator(QuoteRequest quoteRequest)
            : base(quoteRequest)
        {
        }

        public QuoteRequest Message => Decorated<QuoteRequest>();

        public bool IsSetNoRelatedSym() => Message.IsSetNoRelatedSym();
        public NoRelatedSym NoRelatedSym => Message.NoRelatedSym;

        public void AddNoRelatedSymGroup(NoRelatedSymGroupDecorator newGroup)
        {
            Message.AddGroup(newGroup.Decorated);
        }

        public void ReplaceNoRelatedSymGroup(int numGroup, NoRelatedSymGroupDecorator newGroup)
        {
            Message.ReplaceGroup(numGroup, Tags.NoRelatedSym, newGroup.Decorated);
        }

        public NoRelatedSymGroupDecorator GetNoRelatedSymGroup(int groupNum)
        {
            QuoteRequest.NoRelatedSymGroup group = new QuoteRequest.NoRelatedSymGroup();
            Message.GetGroup(groupNum, group);
            return new NoRelatedSymGroupDecorator(group);
        }
    }

    public class NoRelatedSymGroupDecorator : FixGroupDecorator
    {
        public NoRelatedSymGroupDecorator(Group group)
            : base(group)
        {
        }

        public QuoteRequest.NoRelatedSymGroup Decorated => Decorated<QuoteRequest.NoRelatedSymGroup>();

        public bool IsSetSymbol() => Decorated.IsSetSymbol();

        public Symbol Symbol
        {
            get => Decorated.Symbol;
            set => Decorated.Symbol = value;
        }
    }
}
