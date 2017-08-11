using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AxFixEntities
{
    public static class ConvertersGenerator
    {
        public static void Generate()
        {
            SpecDoc spec = SpecDoc.Load(@".\Spec\FIX44.xml");
            TypeMappingDoc typeMap = TypeMappingDoc.Load(@".\Spec\TypeMapping.xml");
            TypeResolver typeResolver = new TypeResolver(spec, typeMap);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Globalization;");
            sb.AppendLine("using QuickFix;");
            sb.AppendLine();
            sb.AppendLine("// Generated file");
            sb.AppendLine();
            sb.AppendLine("namespace FIX44.Entities");
            sb.Append("{\n");

            sb.AppendFormat("public static class Converters\n");
            sb.Append("{\n");

            foreach (var message in spec.Messages)
            {
                sb.AppendFormat("public static {0} ToEntity(this QuickFix.FIX44.{0} v)\n", message.Name);
                sb.Append("{\n");
                sb.AppendFormat("var r = new {0}();\n", message.Name);

                foreach (var field in message.Fields)
                {
                    if (!field.Required)
                    {
                        sb.AppendFormat("if(v.IsSet{0}())\n", field.Name);
                        sb.AppendFormat("r.{0} = {1};\n", field.Name, typeResolver.MakePropertyAssignment("v", field.Name));
                    }
                    else
                    {
                        sb.AppendFormat("r.{0} = {1};\n", field.Name, typeResolver.MakePropertyAssignment("v", field.Name));
                    }
                }

                foreach (var group in message.Groups)
                {
                    var groupInternalType = message.Name + "." + group.Name + "Item";
                    if (group.Required == false)
                    {
                        sb.AppendFormat("if(v.IsSet{0}())\n", group.Name);
                        sb.Append("{\n");
                    }

                    sb.AppendFormat("var {0}List = new List<{1}>();\n", group.Name, groupInternalType);
                    sb.AppendFormat("for (var i = 1; i <= v.{0}.getValue(); i++)\n", group.Name);
                    sb.Append("{\n");
                    sb.AppendFormat("var fixGroup = (QuickFix.FIX44.{0}.{1}Group)v.GetGroup(i, QuickFix.Fields.Tags.{1});\n", message.Name, group.Name);
                    sb.AppendFormat("var groupItem = new {0}();\n", groupInternalType);
                    foreach (var field in @group.Fields)
                    {
                        if (!field.Required)
                        {
                            sb.AppendFormat("if(fixGroup.IsSet{0}())\n", field.Name);
                            sb.AppendFormat("groupItem.{0} = {1};\n", field.Name, typeResolver.MakePropertyAssignment("fixGroup", field.Name));
                        }
                        else
                        {
                            sb.AppendFormat("groupItem.{0} = {1};\n", field.Name, typeResolver.MakePropertyAssignment("fixGroup", field.Name));
                        }
                    }

                    sb.AppendFormat("{0}List.Add(groupItem);\n", group.Name);
                    sb.Append("}\n");

                    sb.AppendFormat("r.{0} = {0}List.ToArray();\n", group.Name);

                    sb.Append(group.Required ? string.Empty : "}\n" );
                }

                sb.AppendLine("return r;\n");

                sb.Append("}\n");
            }

            sb.Append("}\n");

            File.WriteAllText("Converters.cs", sb.ToString());
        }
    }
}
