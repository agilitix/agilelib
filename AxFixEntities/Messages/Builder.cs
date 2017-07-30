using System;
using System.Linq;
using System.Xml.Linq;

namespace AxFixEntities.Messages
{
    public static class Builder
    {
        public static Message CreateMessage(XElement specMessage)
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

        public static Field CreateField(XElement specField)
        {
            if (specField.Name != "field")
            {
                throw new ArgumentException("Invalid argument.", nameof(specField));
            }

            return new Field(specField.Attribute("name").Value,
                             specField.Attribute("required").Value == "Y");
        }

        public static Group CreateGroup(XElement specGroup)
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

        public static Component CreateComponentReference(XElement specComponent)
        {
            if (specComponent.Name != "component")
            {
                throw new ArgumentException("Invalid argument.", nameof(specComponent));
            }

            return new Component(specComponent.Attribute("name").Value,
                                 specComponent.Attribute("required").Value == "Y");
        }

        public static Component CreateComponentDetails(XElement specComponent)
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
