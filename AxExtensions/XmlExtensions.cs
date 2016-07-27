using System;
using System.IO;
using System.Xml.Serialization;

namespace AxExtensions
{
    public static class XmlExtensions
    {
        public static string XmlSerialize<T>(this T self) where T : class, new()
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            // This constructor is thread safe and does not leak the memory.
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, self);
                return writer.ToString();
            }
        }

        public static T XmlDeserialize<T>(this string self) where T : class, new()
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            // This constructor is thread safe and does not leak the memory.
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(self))
            {
                try
                {
                    return (T)serializer.Deserialize(reader);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
