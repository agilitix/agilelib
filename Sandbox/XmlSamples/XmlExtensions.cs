//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Json;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;
//using System.Web.Script.Serialization; // System.Web.Extensions assembly.

//namespace XmlSamples
//{
//    public static class XmlExtensions
//    {
//        private static readonly ConcurrentDictionary<Type, XmlSerializer> XmlSerializers = new ConcurrentDictionary<Type, XmlSerializer>();
//        private static readonly ConcurrentDictionary<Type, DataContractJsonSerializer> JsonSerializers = new ConcurrentDictionary<Type, DataContractJsonSerializer>();

//        private static readonly JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();

//        public enum JsonSerializerType
//        {
//            Undefined = 0,
//            DataContractJsonSerializer = 1,
//            JavaScriptSerializer = 2
//        }

//        /// <summary>
//        /// Serializes the object using XML format.
//        /// </summary>
//        public static string SerializeAsXml(this object obj)
//        {
//            var type = obj.GetType();
//            var xmlSerializer = GetXmlSerializer(type);

//            using (var memStream = new MemoryStream())
//            {
//                xmlSerializer.Serialize(memStream, obj);
//                return Encoding.Default.GetString(memStream.ToArray());
//            }
//        }

//        /// <summary>
//        /// Serializes the object using JSON format, either using the default 
//        /// DataContractJsonSerializer or the JavaScriptSerializer, the results
//        /// differ slightly.
//        /// </summary>
//        public static string SerializeAsJson(this object obj, JsonSerializerType serializerType = JsonSerializerType.DataContractJsonSerializer)
//        {
//            switch (serializerType)
//            {
//                case JsonSerializerType.JavaScriptSerializer:
//                    return JavaScriptSerializer.Serialize(obj);
//                default:
//                    var type = obj.GetType();
//                    var serializer = GetJsonSerializer(type);

//                    using (var memStream = new MemoryStream())
//                    {
//                        serializer.WriteObject(memStream, obj);
//                        return Encoding.Default.GetString(memStream.ToArray());
//                    }
//            }
//        }

//        /// <summary>
//        /// Deserializes the specified XML string to an object of the specified type T.
//        /// </summary>
//        public static T DeserializeAsXml<T>(this string xmlString)
//        {
//            var xmlSerializer = GetXmlSerializer(typeof(T));
//            using (var memStream = new MemoryStream(Encoding.Default.GetBytes(xmlString)))
//            {
//                return (T) xmlSerializer.Deserialize(memStream);
//            }
//        }

//        /// <summary>
//        /// Deserializes the specified JSON string to an object of the specified type T.
//        /// </summary>
//        public static T DeserializeAsJson<T>(this string jsonString, JsonSerializerType serializerType = JsonSerializerType.DataContractJsonSerializer)
//        {
//            switch (serializerType)
//            {
//                case JsonSerializerType.JavaScriptSerializer:
//                    return JavaScriptSerializer.Deserialize<T>(jsonString);
//                default:
//                    var serializer = GetJsonSerializer(typeof(T));

//                    using (var memStream = new MemoryStream(Encoding.Default.GetBytes(jsonString)))
//                    {
//                        return (T) serializer.ReadObject(memStream);
//                    }
//            }
//        }

//        private static XmlSerializer GetXmlSerializer(Type type)
//        {
//            // gets the xml serializer from the concurrent dictionary, if it doesn't exist
//            // then add one for the specified type
//            return XmlSerializers.GetOrAdd(type, t => new XmlSerializer(t));
//        }

//        private static DataContractJsonSerializer GetJsonSerializer(Type type)
//        {
//            // gets the json serializer from the concurrent dictionary, if it doesn't exist
//            // then add one for the specified type
//            return JsonSerializers.GetOrAdd(type, t => new DataContractJsonSerializer(t));
//        }
//    }
//}
