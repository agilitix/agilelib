using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AxFixEntities.TypeMapping
{
    public class TypeMappingDoc
    {
        private readonly XDocument _mappingsDoc;

        private TypeMappingDoc(XDocument mappingsDoc)
        {
            _mappingsDoc = mappingsDoc;
        }

        public static TypeMappingDoc Load(string path)
        {
            return new TypeMappingDoc(XDocument.Load(path));
        }

        public IEnumerable<TypeMapping> TypeMappings
        {
            get
            {
                return _mappingsDoc.Root
                                   .Elements("map")
                                   .Select(x => new TypeMapping(x.Attribute("fixType").Value,
                                                                x.Attribute("clrType").Value,
                                                                x.Attributes("parseExpression").Any()
                                                                    ? x.Attribute("parseExpression").Value
                                                                    : null));
            }
        }

        public string this[string fixType]
        {
            get
            {
                TypeMapping typeMapping = TypeMappings.SingleOrDefault(m => m.FixType == fixType);
                return typeMapping.ClrType;
            }
        }

        public string GetParseExpression(string fixType)
        {
            TypeMapping typeMapping = TypeMappings.SingleOrDefault(m => m.FixType == fixType);
            return typeMapping.ParseExpression;
        }
    }
}
