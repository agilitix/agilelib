using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlSamples
{
    public class XmlUtils
    {
        public static XDocument ToXDocument<T>(T source)
        {
            var result = new XDocument();
            using (var writer = result.CreateWriter())
            {
                var serializer = new XmlSerializer(source.GetType());
                serializer.Serialize(writer, source);
            }
            return result;
        }

        public static XmlDocument ToXmlDocument<T>(T source)
            where T : new()
        {
            var result = new XmlDocument();
            using (var ms = new MemoryStream())
            {
                var serializer = new XmlSerializer(source.GetType());
                serializer.Serialize(ms, source);
                ms.Flush();
                ms.Position = 0;
                result.Load(ms);
            }
            return result;
        }

        public static T Deserialize<T>(XDocument serialized)
        {
            using (var reader = serialized.CreateReader())
            {
                var deserializer = new XmlSerializer(typeof(T));
                return (T)deserializer.Deserialize(reader);
            }
        }

        public static T Deserialize<T>(XmlDocument serialized)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var xmlStream = new MemoryStream())
            {
                serialized.Save(xmlStream);
                xmlStream.Flush();
                xmlStream.Position = 0;
                using (TextReader reader = new StreamReader(xmlStream))
                {
                    return (T)xmlSerializer.Deserialize(reader);
                }
            }
        }

        public static XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var result = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                result.Load(xmlReader);
            }
            return result;
        }

        public static XDocument ToXDocument(XmlDocument xmlDocument)
        {
            using (var reader = new XmlNodeReader(xmlDocument))
            {
                reader.MoveToContent();
                return XDocument.Load(reader);
            }
        }
    }
}
