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
        protected const string _mappedFieldPrefix = "_col_";
        protected readonly Dictionary<string, FieldInfo> _fields;
        protected readonly Type _entityType;

        public EntityMapper()
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            _fields = typeof(TEntity).GetFields(flags)
                                     .Where(x => x.Name.StartsWith(_mappedFieldPrefix))
                                     .ToDictionary(x => x.Name.Substring(_mappedFieldPrefix.Length), x => x);
            _entityType = typeof(TEntity);
        }

        public DataTable Map(IEnumerable<TEntity> entities)
        {
            DataTable table = new DataTable(_entityType.Name);
            foreach (KeyValuePair<string, FieldInfo> field in _fields)
            {
                Type fieldType = Nullable.GetUnderlyingType(field.Value.FieldType) ?? field.Value.FieldType;
                table.Columns.Add(field.Key, fieldType);
            }

            foreach (TEntity entity in entities)
            {
                DataRow row = table.NewRow();
                foreach (KeyValuePair<string, FieldInfo> field in _fields)
                {
                    row[field.Key] = field.Value.GetValue(entity) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public IEnumerable<TEntity> Map(DataTable dataTable)
        {
            IList<string> columns = dataTable.Columns
                                             .Cast<DataColumn>()
                                             .Select(x => x.ColumnName)
                                             .ToList();

            IList<TEntity> result = new List<TEntity>();

            foreach (DataRow row in dataTable.Rows)
            {
                TEntity entity = new TEntity();
                result.Add(entity);

                foreach (string column in columns)
                {
                    object value = row[column];
                    if (value == DBNull.Value)
                    {
                        continue;
                    }

                    FieldInfo field;
                    if (_fields.TryGetValue(column, out field))
                    {
                        Type fieldType = Nullable.GetUnderlyingType(field.FieldType) ?? field.FieldType;
                        field.SetValue(entity, ChangeDbValue(value, fieldType));
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
