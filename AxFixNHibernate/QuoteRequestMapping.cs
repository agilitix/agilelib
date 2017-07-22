using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace AxFixNHibernate
{
    public class QuoteRequestFix44Mapping : ClassMapping<QuickFix.FIX44.QuoteRequest>
    {
        public QuoteRequestFix44Mapping()
        {
            Table("ta_" + nameof(QuickFix.FIX44.QuoteRequest).ToLower());

            Property(x => x.ClOrdID,
                     m =>
                     {
                         m.Column(nameof(QuickFix.FIX44.QuoteRequest.ClOrdID));
                         m.Type<StringType>();
                         m.Length(32);
                     });

            Property(x => x.EncodedText,
                     m =>
                     {
                         m.Column(nameof(QuickFix.FIX44.QuoteRequest.EncodedText));
                         m.Type<StringType>();
                         m.Length(1024);
                     });

            Property(x => x.NoRelatedSym,
                     m =>
                     {
                         m.Column(nameof(QuickFix.FIX44.QuoteRequest.EncodedText));
                         m.Type<StringType>();
                         m.Length(1024);
                     });
        }
    }
}
