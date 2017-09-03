using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using AxData.Interfaces;
using AxUtils;

namespace AxData
{
    public class EntityMapper<TEntity> : IEntityMapper<TEntity> where TEntity : class, new()
    {
        protected IDictionary<string, PropertyInfo> _properties;
        protected Dictionary<string, FieldInfo> _fields;

        public EntityMapper()
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            _properties = typeof(TEntity).GetProperties(flags).Where(x => x.CanWrite).ToDictionary(x => x.Name, x => x);
            _fields = typeof(TEntity).GetFields(flags).ToDictionary(x => x.Name, x => x);
        }

        public IEnumerable<TEntity> Map(DataTable dataTable)
        {
            Dictionary<string, DataColumn> columns = dataTable.Columns
                                                              .Cast<DataColumn>()
                                                              .ToDictionary(x => x.ColumnName, x => x);

            IList<TEntity> result = new List<TEntity>();

            foreach (var row in dataTable.AsEnumerable())
            {
                var entity = new TEntity();
                result.Add(entity);

                foreach (KeyValuePair<string, DataColumn> column in columns)
                {
                    object value = row[column.Key];
                    if (value == DBNull.Value)
                    {
                        continue;
                    }

                    PropertyInfo property;
                    if (_properties.TryGetValue(column.Key, out property))
                    {
                        Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        property.SetValue(entity, ChangeDbValue(value, propertyType), null);
                    }
                    else
                    {
                        FieldInfo field;
                        if (_fields.TryGetValue("_" + column.Key, out field)
                            || _fields.TryGetValue(column.Key, out field))
                        {
                            Type fieldType = Nullable.GetUnderlyingType(field.FieldType) ?? field.FieldType;
                            field.SetValue(entity, ChangeDbValue(value, fieldType));
                        }
                    }
                }
            }

            return result;
        }

        // To be continued with other types not managed by Convert.ChangeType
        private static object ChangeDbValue(object dbValue, Type type)
        {
            if (type == typeof(bool))
            {
                return (bool) ToBoolean(dbValue);
            }

            return Convert.ChangeType(dbValue, type);
        }

        private static object ToBoolean(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return false;
            }

            string val = value.ToString().ToLowerInvariant();
            return val == "1" || val == "true" || val == "y" || val == "yes";
        }
    }
}
