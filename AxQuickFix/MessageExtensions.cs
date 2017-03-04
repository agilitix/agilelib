using System.Collections.Generic;
using System.Xml.Linq;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxQuickFix
{
    public static class MessageExtensions
    {
        public static string GetName(this Message self, DataDictionary dictionary)
        {
            string msgType = self.Header.GetField(Tags.MsgType);
            string msgName = dictionary.GetEnumLabel(Tags.MsgType, msgType);
            return msgName;
        }

        public static XDocument ToXDocument(this Message self, DataDictionary dictionary)
        {
            string msgName = GetName(self, dictionary);
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            XElement root = new XElement("message");
            root.Add(new XAttribute("name", msgName));
            doc.Add(root);

            XElement header = new XElement("header");
            root.Add(header);
            foreach (KeyValuePair<int, IField> field in self.Header)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                header.Add(fieldElement);
            }

            XElement body = new XElement("body");
            root.Add(body);
            foreach (KeyValuePair<int, IField> field in self)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                body.Add(fieldElement);
            }

            XElement trailer = new XElement("trailer");
            root.Add(trailer);
            foreach (KeyValuePair<int, IField> field in self.Trailer)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                trailer.Add(fieldElement);
            }

            return doc;
        }

        private static XElement CreateElement(KeyValuePair<int, IField> field, DataDictionary dictionary)
        {
            string fieldName = dictionary.GetFieldName(field.Key);
            string fieldValue = field.Value.ToString();
            string fieldFixType = dictionary.GetFieldFixType(field.Key);

            XElement element = new XElement(fieldName);

            element.Add(new XAttribute("tag", field.Key));

            if (fieldFixType.Equals("DATA"))
            {
                try
                {
                    XElement data = XElement.Parse(fieldValue);
                    element.Add(data);
                }
                catch
                {
                    element.Add(new XCData(fieldValue));
                }
            }
            else
            {
                element.Add(new XAttribute("value", fieldValue));
                string name = dictionary.GetEnumLabel(field.Key, fieldValue);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    element.Add(new XAttribute("desc", name));
                }
            }

            element.Add(new XAttribute("type", fieldFixType));

            return element;
        }
    }
}
