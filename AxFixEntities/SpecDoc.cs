using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AxFixEntities.FixSpec;
using AxFixEntities.Messages;

namespace AxFixEntities
{
    public class SpecDoc
    {
        private readonly XDocument _specDoc;

        public IEnumerable<Message> Messages => _specDoc.Root.Element("messages").Elements("message").Select(CreateMessage);
        public IEnumerable<SpecField> Fields => _specDoc.Root.Element("fields").Elements("field").Select(CreateSpecField);
        public IEnumerable<Component> Components => _specDoc.Root.Element("components").Elements("component").Select(CreateComponentReference);
        public IEnumerable<Component> ComponentsDetails => _specDoc.Root.Element("components").Elements("component").Select(CreateComponentDetails);

        private SpecDoc(XDocument specDoc)
        {
            _specDoc = specDoc;
        }

        public static SpecDoc Load(string path)
        {
            return new SpecDoc(XDocument.Load(path));
        }


        private static SpecField CreateSpecField(XElement specElement)
        {
            if (specElement.Name != "field")
            {
                throw new ArgumentException("Invalid argument", nameof(specElement));
            }

            return new SpecField(int.Parse(specElement.Attribute("number").Value),
                                 specElement.Attribute("name").Value,
                                 specElement.Attribute("type").Value,
                                 specElement.Elements("value").Select(CreateSpecValue));
        }

        private static SpecValue CreateSpecValue(XElement elt)
        {
            return new SpecValue(elt.Attribute("enum").Value,
                                 elt.Attribute("description").Value);
        }

        private static Message CreateMessage(XElement specMessage)
        {
            if (specMessage.Name != "message")
            {
                throw new ArgumentException("Invalid argument.", nameof(specMessage));
            }

            return new Message(specMessage.Attribute("name").Value,
                               specMessage.Elements("field").Select(CreateField),
                               specMessage.Elements("group").Select(CreateGroup),
                               specMessage.Elements("component").Select(CreateComponentReference));
        }

        private static Field CreateField(XElement specField)
        {
            if (specField.Name != "field")
            {
                throw new ArgumentException("Invalid argument.", nameof(specField));
            }

            return new Field(specField.Attribute("name").Value,
                             specField.Attribute("required").Value == "Y");
        }

        private static Group CreateGroup(XElement specGroup)
        {
            if (specGroup.Name != "group")
            {
                throw new ArgumentException("Invalid argument.", nameof(specGroup));
            }

            return new Group(specGroup.Attribute("name").Value,
                             specGroup.Attribute("required").Value == "Y",
                             specGroup.Elements("field").Select(CreateField),
                             specGroup.Elements("component").Select(CreateComponentReference));
        }

        private static Component CreateComponentReference(XElement specComponent)
        {
            if (specComponent.Name != "component")
            {
                throw new ArgumentException("Invalid argument.", nameof(specComponent));
            }

            return new Component(specComponent.Attribute("name").Value,
                                 specComponent.Attribute("required").Value == "Y");
        }

        private static Component CreateComponentDetails(XElement specComponent)
        {
            if (specComponent.Name != "component")
            {
                throw new ArgumentException("Invalid argument.", nameof(specComponent));
            }

            return new Component(specComponent.Attribute("name").Value,
                                 specComponent.Elements("field").Select(CreateField),
                                 specComponent.Elements("group").Select(CreateGroup));
        }
    }
}
