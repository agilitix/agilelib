using System.Linq;
using AxFixEntities.FixSpec;
using AxFixEntities.Messages;

namespace AxFixEntities.TypeMapping
{
    public class TypeResolver
    {
        private readonly SpecDoc _specDoc;
        private readonly TypeMappingDoc _typeMappingDoc;

        public TypeResolver(SpecDoc specDoc, TypeMappingDoc typeMappingDoc)
        {
            _specDoc = specDoc;
            _typeMappingDoc = typeMappingDoc;
        }

        public string MakePropertyAssignment(string prefix, string fieldName)
        {
            SpecField f = _specDoc.Fields.Single(c => c.Name == fieldName);
            string fixType = f.Type;

            if (f.Values.Any())
            {
                return f.Name + ".Parse(" + prefix + "." + fieldName + ".getValue())";
            }

            string parseExpression = _typeMappingDoc.GetParseExpression(f.Type);
            if (!string.IsNullOrWhiteSpace(parseExpression))
            {
                return "(" + _typeMappingDoc[fixType] + ")" + _typeMappingDoc[fixType] + string.Format(parseExpression, prefix + "." + fieldName + ".getValue()");
            }

            return "(" + _typeMappingDoc[fixType] + ")" + prefix + "." + fieldName + ".getValue()";
        }

        public string Resolve(Field field)
        {
            SpecField f = _specDoc.Fields.Single(c => c.Name == field.Name);
            string fixType = f.Type;
            string clrType = _typeMappingDoc[fixType];
            bool @enum = f.Values.Any();
            if (@enum && clrType == "bool")
            {
                return clrType;
            }

            if (@enum)
            {
                return field.Name;
            }

            string nullableMark = string.Empty;
            if (field.Required == false && clrType != "string")
            {
                nullableMark = "?";
            }

            return string.Format("{0}{1}", clrType, nullableMark);
        }
    }
}
