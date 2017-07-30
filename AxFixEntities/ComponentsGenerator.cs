using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AxFixEntities.FixSpec;
using AxFixEntities.TypeMapping;

namespace AxFixEntities
{
    public static class ComponentsGenerator
    {
        public static void GenerateComponents()
        {
            SpecDoc spec = SpecDoc.Load(@".\Spec\FIX44.xml");
            TypeMappingDoc typeMap = TypeMappingDoc.Load(@".\Spec\TypeMapping.xml");
            TypeResolver typeResolver = new TypeResolver(spec, typeMap);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("// Generated file");
            sb.AppendLine();
            sb.AppendLine("namespace AxFixEntities");
            sb.Append("{\n");

            var c = spec.Components;

            foreach (var component in spec.ComponentsDetails)
            {
                sb.AppendFormat("  public class {0}\n", component.Name);
                sb.Append("  {\n");
                foreach (var field in component.Fields)
                {
                    sb.AppendFormat("    public {0} {1} {{ get; set; }}\n", typeResolver.Resolve(field), field.Name);
                }

                foreach (var group in component.Groups)
                {
                    sb.AppendFormat("    public {0}Item[] {0} {{ get; set; }}\n", group.Name);
                    sb.AppendFormat("    public class {0}Item\n", group.Name);
                    sb.Append("    {\n");
                    foreach (var field in group.Fields)
                    {
                        sb.AppendFormat("      public {0} {1} {{ get; set; }}\n", typeResolver.Resolve(field), field.Name);
                    }

                    sb.Append("    }\n");
                }

                sb.Append("  }\n");

                sb.AppendLine();
            }

            sb.Append("}\n");

            File.WriteAllText("Components.cs", sb.ToString());
        }
    }
}
