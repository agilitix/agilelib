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
    class Program
    {
        static void Main(string[] args)
        {
            EnumsGenerator.Generate();
            MessagesGenerator.GenerateMessages();
            ComponentsGenerator.GenerateComponents();
        }
    }
}
