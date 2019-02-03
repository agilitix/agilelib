//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.Serialization;

//namespace XmlSamples
//{
//    public class XmlHelper
//    {
//        public string ToString<T>(T obj)
//        {
//            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
//            namespaces.Add(string.Empty, string.Empty);
//            XmlWriterSettings settings = new XmlWriterSettings
//                                         {
//                                             Indent = true,
//                                         };

//            var serializer = new XmlSerializer(typeof(T));
//            var sb = new StringBuilder();
//            using (XmlWriter writer = XmlWriter.Create(sb, settings))
//            {
//                serializer.Serialize(writer, obj, namespaces);
//            }

//            return sb.ToString();
//        }

//        public string ToString(XmlDocument doc)
//        {
//            XmlWriterSettings settings = new XmlWriterSettings
//                                         {
//                                             Indent = true,
//                                         };

//            var sb = new StringBuilder();
//            using (var xmlWriter = XmlWriter.Create(sb, settings))
//            {
//                doc.WriteTo(xmlWriter);
//            }

//            return sb.ToString();
//        }

//        public T FromString<T>(string xml)
//        {
//            T result;
//            var serializer = new XmlSerializer(typeof(T));
//            using (var reader = new StringReader(xml))
//            {
//                result = (T) serializer.Deserialize(reader);
//            }

//            return result;
//        }

//        public XDocument ToXDocument<T>(T obj)
//        {
//            XDocument doc = new XDocument();
//            using (XmlWriter writer = doc.CreateWriter())
//            {
//                var dcSerializer = new DataContractSerializer(typeof(T));
//                dcSerializer.WriteObject(writer, obj);
//            }

//            foreach (XElement descendant in doc.Descendants())
//            {
//                descendant.Attributes()
//                          .Where(x => x.IsNamespaceDeclaration)
//                          .Remove();
//                descendant.Name = descendant.Name.LocalName;
//            }

//            return doc;
//        }

//        public XmlDocument ToXmlDocument<T>(T obj)
//        {
//            XDocument xdoc = ToXDocument(obj);
//            XmlDocument xmldoc = new XmlDocument();
//            using (XmlReader xmlreader = xdoc.CreateReader())
//            {
//                xmldoc.Load(xmlreader);
//            }

//            return xmldoc;
//        }
//    }
//}
