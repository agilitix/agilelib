using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlSamples
{
    //[DataContract]
    public class Book
    {
        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public string Author { get; set; }
    }

    //[DataContract]
    public class BookStore
    {
        //[DataMember]
        public List<Book> Books { get; set; } = new List<Book>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookStore bs = new BookStore();
            bs.Books.Add(new Book {Name = "Republic", Author = "Platon"});
            bs.Books.Add(new Book {Name = "Odyssey", Author = "Homer"});

            string xml = "";

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(BookStore));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, bs, namespaces);
                xml = writer.ToString();
            }

            Console.WriteLine(xml);

            Console.WriteLine();

            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            using (XmlWriter writer = doc.CreateWriter())
            {
                var dcSerializer = new DataContractSerializer(typeof(BookStore));
                dcSerializer.WriteObject(writer, bs);
            }

            // Cleanup namespaces.
            foreach (XElement descendant in doc.Descendants())
            {
                descendant.Attributes()
                          .Where(x => x.IsNamespaceDeclaration)
                          .Remove();
                descendant.Name = descendant.Name.LocalName;
            }

            using (XmlTextWriter f = new XmlTextWriter("output.xml", Encoding.UTF8))
            {
                f.Formatting = Formatting.Indented;
                doc.WriteTo(f);
            }

            Console.WriteLine(doc.Declaration + Environment.NewLine + doc);
        }
    }
}
