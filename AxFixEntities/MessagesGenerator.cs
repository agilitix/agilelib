﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AxFixEntities.FixSpec;
using AxFixEntities.TypeMapping;

namespace AxFixEntities
{
    public static class MessagesGenerator
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
            sb.AppendLine();
            sb.AppendLine("// Generated file");
            sb.AppendLine();
            sb.AppendLine("namespace FIX44.Entities");
            sb.Append("{\n");

            var c = spec.Components;

            foreach (var message in spec.Messages)
            {
                sb.AppendFormat("  public class {0}\n", message.Name);
                sb.Append("  {\n");
                foreach (var field in message.Fields)
                {
                    sb.AppendFormat("    public {0} {1} {{ get; set; }}\n", typeResolver.Resolve(field), field.Name);
                }

                foreach (var component in message.Components)
                {
                    sb.AppendFormat("    public {0} {1} {{ get; set; }}\n", component.Name + (component.Required ? "" : "?"), component.Name);
                }

                foreach (var group in message.Groups)
                {
                    sb.AppendFormat("    public {0}Item[] {0} {{ get; set; }}\n", group.Name);
                    sb.AppendFormat("    public struct {0}Item\n", group.Name);
                    sb.Append("    {\n");
                    foreach (var field in group.Fields)
                    {
                        sb.AppendFormat("      public {0} {1} {{ get; set; }}\n", typeResolver.Resolve(field), field.Name);
                    }

                    foreach (var component in group.Components)
                    {
                        sb.AppendFormat("      public {0} {1} {{ get; set; }}\n", component.Name + (component.Required ? "" : "?"), component.Name);
                    }

                    sb.Append("    }\n");
                }

                sb.Append("  }\n");

                sb.AppendLine();
            }

            sb.Append("}\n");

            File.WriteAllText("Messages.cs", sb.ToString());
        }
    }
}
