using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AxUtils
{
    static class PropertyUtils
    {
        public static IEnumerable<PropertyInfo> GetAllProperties<T>()
            where T : class
        {
            return GetAllProperties(typeof(T));
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            if (type == null)
            {
                return Enumerable.Empty<PropertyInfo>();
            }

            return type.GetProperties(BindingFlags.Public
                                      | BindingFlags.NonPublic
                                      | BindingFlags.Static
                                      | BindingFlags.Instance
                                      | BindingFlags.DeclaredOnly)
                       .Union(GetAllProperties(type.BaseType));
        }

        public static IEnumerable<Tuple<PropertyInfo, TAttribute>> GetAllPropertiesAttributes<T, TAttribute>()
            where T : class
            where TAttribute : Attribute
        {
            return GetAllPropertiesAttributes<TAttribute>(typeof(T));
        }

        public static IEnumerable<Tuple<PropertyInfo, TAttribute>> GetAllPropertiesAttributes<TAttribute>(Type type)
            where TAttribute : Attribute
        {
            if (type == null)
            {
                return Enumerable.Empty<Tuple<PropertyInfo, TAttribute>>();
            }

            return type.GetProperties(BindingFlags.Public
                                      | BindingFlags.NonPublic
                                      | BindingFlags.Static
                                      | BindingFlags.Instance
                                      | BindingFlags.DeclaredOnly)
                       .Select(propInfo => new {PropInfo = propInfo, Attributes = propInfo.GetCustomAttributes(typeof(TAttribute), false)})
                       .SelectMany(t => t.Attributes, (t, a) => new {Type = t, a})
                       .Select(t => new Tuple<PropertyInfo, TAttribute>(t.Type.PropInfo, (TAttribute) t.a))
                       .Union(GetAllPropertiesAttributes<TAttribute>(type.BaseType));
        }
    }
}
