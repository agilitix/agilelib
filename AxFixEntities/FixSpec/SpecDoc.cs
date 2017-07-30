using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AxFixEntities.Messages;

namespace AxFixEntities.FixSpec
{
    public class SpecDoc
    {
        private readonly XDocument _specDoc;

        public IEnumerable<Message> Messages => _specDoc.Root.Element("messages").Elements("message").Select(Builder.CreateMessage);
        public IEnumerable<SpecField> Fields => _specDoc.Root.Element("fields").Elements("field").Select(ToSpecField);
        public IEnumerable<Component> Components => _specDoc.Root.Element("components").Elements("component").Select(Builder.CreateComponentReference);
        public IEnumerable<Component> ComponentsDetails => _specDoc.Root.Element("components").Elements("component").Select(Builder.CreateComponentDetails);

        private SpecDoc(XDocument specDoc)
        {
            _specDoc = specDoc;
        }

        public static SpecDoc Load(string path)
        {
            return new SpecDoc(XDocument.Load(path));
        }


        public static SpecField ToSpecField(XElement specElement)
        {
            if (specElement.Name != "field")
            {
                throw new ArgumentException("Invalid argument", nameof(specElement));
            }

            return new SpecField(int.Parse(specElement.Attribute("number").Value),
                                 specElement.Attribute("name").Value,
                                 specElement.Attribute("type").Value,
                                 specElement.Elements("value").Select(ToValue));
        }

        private static SpecValue ToValue(XElement elt)
        {
            return new SpecValue(elt.Attribute("enum").Value,
                                 elt.Attribute("description").Value);
        }
    }
}
