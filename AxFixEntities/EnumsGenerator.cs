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
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine();
            sb.AppendLine("// Generated file");
            sb.AppendLine();
            sb.AppendLine("namespace FIX44.Entities");
            sb.Append("{\n");

            foreach (var field in spec.Fields.Where(f => f.Values.Any()))
            {
                string clrType = typeMap[field.Type];

                sb.Append("  [DebuggerDisplay(\"{ToEnumName()}\")]\n");
                sb.AppendFormat("  public struct {0} : IEquatable<{0}>\n", field.Name);
                sb.Append("  {\n");
                sb.AppendFormat("    private static IDictionary<{0}, string> _possibleValues = new Dictionary<{0}, string> {{", clrType);
                foreach (var value in field.Values)
                {
                    sb.AppendFormat("{{{0},\"{1}\"}},", EscapeWithType(value.EnumValue, clrType), DeHumanize(value.Description)); //EscapePropertyName(value.Description)));
                }

                sb.Append("};\n");

                sb.AppendFormat("    private readonly {0} _value;\n", clrType + (clrType != "string" ? "?" : ""));
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
                sb.AppendFormat("    public static bool operator ==({0} left, {0} right)\n", field.Name);
                sb.Append("    {\n");
                sb.Append("      return left.Equals(right);\n");
                sb.Append("    }\n");
                sb.AppendFormat("    public static bool operator !=({0} left, {0} right)\n", field.Name);
                sb.Append("    {\n");
                sb.Append("      return !left.Equals(right);\n");
                sb.Append("    }\n");

                if (clrType == "int")
                {
                    sb.AppendFormat("    public override int GetHashCode()\n");
                    sb.Append("    {\n");
                    sb.Append("      return _value.GetHashCode();\n");
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(int value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (_possibleValues.ContainsKey(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public string ToEnumName()\n");
                    sb.Append("    {\n");
                    sb.Append("      string name;\n");
                    sb.Append("      return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;\n");
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
                    sb.Append("      if (_possibleValues.ContainsKey(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public static {0} FromValue(string value)\n", field.Name);
                    sb.Append("    {\n");
                    sb.Append("      if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value[0]);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public string ToEnumName()\n");
                    sb.Append("    {\n");
                    sb.Append("      string name;\n");
                    sb.Append("      return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;\n");
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
                    sb.Append("      if (_possibleValues.ContainsKey(value) == false)\n");
                    sb.AppendFormat("        throw new ArgumentException(\"Value [\" + value + \"] is not supported for {0}\", nameof(value));\n", field.Name);
                    sb.AppendFormat("      return new {0}(value);\n", field.Name);
                    sb.Append("    }\n");
                    sb.AppendFormat("    public string ToEnumName()\n");
                    sb.Append("    {\n");
                    sb.Append("      string name;\n");
                    sb.Append("      return _possibleValues.TryGetValue(_value, out name) ? name : null;\n");
                    sb.Append("    }\n");
                }

                sb.AppendFormat("    public static {0} FromEnumName(string name)\n", field.Name);
                sb.Append("    {\n");
                sb.Append("      foreach(var possibleValue in _possibleValues)\n");
                sb.Append("      {\n");
                sb.Append("        if(possibleValue.Value == name)\n");
                sb.AppendFormat("          return new {0}(possibleValue.Key);\n", field.Name);
                sb.Append("      }\n");
                sb.Append("     return Invalid;\n");
                sb.Append("    }\n");

                sb.Append("    public bool IsValid()\n");
                sb.Append("    {\n");
                sb.Append("      return !Equals(Invalid);\n");
                sb.Append("    }\n");

                sb.AppendFormat("    public static {0} Invalid\n", field.Name);
                sb.Append("    {\n");
                sb.AppendFormat("      get {{ return new {0}(); }}\n", field.Name);
                sb.Append("    }\n");

                foreach (var value in field.Values)
                {
                    sb.AppendFormat("    public static {0} {1}\n", field.Name, DeHumanize(value.Description)); //EscapePropertyName(value.Description)));
                    sb.Append("    {\n");
                    sb.AppendFormat("      get {{ return new {0}({1}); }}\n", field.Name, EscapeWithType(value.EnumValue, clrType));
                    sb.Append("    }\n");
                }

                sb.Append("  }\n");
                sb.AppendLine();
            }

            sb.Append("}\n");

            File.WriteAllText("Enums.cs", sb.ToString());
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

        //private static string EscapePropertyName(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(name), "Property name cannot be empty or whitespace.");
        //    }

        //    return char.IsDigit(name[0]) ? "_" + name : name;
        //}
    }
}
