using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AxFixEntities.FixSpec;
using AxFixEntities.TypeMapping;

namespace AxFixEntities
{
    public static class EnumsGenerator
    {
        public static void Generate()
        {
            SpecDoc spec = SpecDoc.Load(@".\Spec\FIX44.xml");
            TypeMappingDoc typeMap = TypeMappingDoc.Load(@".\Spec\TypeMapping.xml");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine();
            sb.AppendLine("namespace AxFixEntities");
            sb.Append("{\n");
            foreach (var field in spec.Fields.Where(f => f.Values.Any()))
            {
                string clrType = typeMap[field.Type];

                sb.AppendFormat("  public struct {0} : IEquatable<{0}>\n", field.Name);
                sb.Append("  {\n");
                sb.AppendFormat("    private static {0}[] _possibleValues = new[] {{{1}}};\n", clrType, string.Join(",", field.Values.Select(v => EscapeWithType(v.Enum, clrType)).Distinct()));
                sb.AppendFormat("    private {0} _value;\n", clrType);
                sb.AppendFormat("    private {0}({1} value)\n", field.Name, clrType);
                sb.Append("    {\n");
                sb.Append("      _value = value;\n");
                sb.Append("    }\n");
                sb.AppendFormat("    public bool Equals({0} other)\n", field.Name);
                sb.Append("    {\n");
                sb.Append("      return _value == other._value;\n");
                sb.Append("    }\n");
                sb.AppendFormat("    public override bool Equals(object other)\n");
                sb.Append("    {\n");
                sb.Append("      if (ReferenceEquals(null, other))\n");
                sb.Append("        return false;\n");
                sb.AppendFormat("      return other is {0} && Equals(({0}) other);\n", field.Name);
                sb.Append("    }\n");

                if (clrType == "int")
                {
                    sb.AppendFormat("    public override int GetHashCode()\n");
                    sb.Append("    {\n");
                    sb.Append("      return _value.GetHashCode();\n");
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(int value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (_possibleValues.Contains(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public {0} Invalid\n", field.Name);
                    sb.Append("    {\n");
                    sb.AppendFormat("      get {{ return new {0} {{ _value=-1 }}; }}\n", field.Name);
                    sb.Append("    }\n");
                }
                else if (clrType == "char")
                {
                    sb.AppendFormat("    public override int GetHashCode()\n");
                    sb.Append("    {\n");
                    sb.Append("      return _value.GetHashCode();\n");
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(char value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (_possibleValues.Contains(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(string value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (value.Length != 1 || _possibleValues.Contains(value[0]) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value[0]);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public {0} Invalid\n", field.Name);
                    sb.Append("    {\n");
                    sb.AppendFormat("      get {{ return new {0} {{ _value=(char)0 }}; }}\n", field.Name);
                    sb.Append("    }\n");
                }
                else if (clrType == "string")
                {
                    sb.AppendFormat("    public override int GetHashCode()\n");
                    sb.Append("    {\n");
                    sb.Append("      return _value?.GetHashCode() ?? 0;\n");
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(string value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (_possibleValues.Contains(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public {0} Invalid\n", field.Name);
                    sb.Append("    {\n");
                    sb.AppendFormat("      get {{ return new {0} {{ _value=string.Empty }}; }}\n", field.Name);
                    sb.Append("    }\n");
                }

                foreach (var value in field.Values)
                {
                    sb.AppendFormat("    public static {0} {1}\n", field.Name, DeHumanize(EscapePropertyName(value.Description)));
                    sb.Append("    {\n");
                    sb.AppendFormat("      get {{ return new {0}({1}); }}\n", field.Name, EscapeWithType(value.Enum, clrType));
                    sb.Append("    }\n");
                }

                sb.Append("  }\n");
                sb.AppendLine();
            }

            sb.Append("}\n");

            File.WriteAllText("Enums.cs", sb.ToString());

            Console.WriteLine(sb);
        }

        private static string DeHumanize(string input)
        {
            string[] splits = input.Split('_');
            return string.Join("", splits.Select(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.ToLower())));
        }

        private static string EscapeWithType(string value, string type)
        {
            switch (type)
            {
                case "string":
                    return "\"" + value + "\"";
                case "char":
                    return "'" + value + "'";
                default:
                    return value;
            }
        }

        private static string EscapePropertyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name), "Property name cannot be empty or whitespace.");
            }

            return char.IsDigit(name[0]) ? "_" + name : name;
        }
    }
}
