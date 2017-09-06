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
        protected const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        protected readonly IDictionary<string, FieldInfo> _fields;
        protected readonly Type _entityType;
        protected readonly DataTable _tablePrototype;

        public EntityMapper()
        {
            _entityType = typeof(TEntity);

            _fields = _entityType.GetFields(flags)
                                 .Where(x => x.Name.StartsWith(_mappedFieldPrefix))
                                 .ToDictionary(x => x.Name.Substring(_mappedFieldPrefix.Length), x => x);

            _tablePrototype = new DataTable(_entityType.Name);
            foreach (KeyValuePair<string, FieldInfo> field in _fields)
            {
                Type fieldType = Nullable.GetUnderlyingType(field.Value.FieldType) ?? field.Value.FieldType;
                _tablePrototype.Columns.Add(field.Key, fieldType);
            }
        }

        public DataTable Map(IEnumerable<TEntity> entities)
        {
            DataTable table = _tablePrototype.Clone();
            foreach (TEntity entity in entities)
            {
                DataRow row = Map(entity);
                table.ImportRow(row);
            }

            return table;
        }

        public DataRow Map(TEntity entity)
        {
            DataTable table = _tablePrototype.Clone();
            DataRow row = table.NewRow();
            foreach (KeyValuePair<string, FieldInfo> field in _fields)
            {
                // GetValue should be extracted to another method to manage DbValue conversions.
                row[field.Key] = field.Value.GetValue(entity) ?? DBNull.Value;
            }

            table.Rows.Add(row);
            return row;
        }

        public IEnumerable<TEntity> Map(DataTable dataTable)
        {
            IList<TEntity> result = new List<TEntity>();
            foreach (DataRow row in dataTable.Rows)
            {
                TEntity entity = Map(row);
                result.Add(entity);
            }

            return result;
        }

        public TEntity Map(DataRow dataRow)
        {
            TEntity entity = new TEntity();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                object value = dataRow[column.ColumnName];
                if (value == DBNull.Value)
                {
                    continue;
                }

                FieldInfo field;
                if (_fields.TryGetValue(column.ColumnName, out field))
                {
                    Type fieldType = Nullable.GetUnderlyingType(field.FieldType) ?? field.FieldType;
                    field.SetValue(entity, ChangeDbValue(value, fieldType));
                }
            }

            return entity;
        }

        // To be continued with other types not managed by Convert.ChangeType
        private static object ChangeDbValue(object dbValue, Type type)
        {
            if (type == typeof(bool))
            {
                return ToBoolean(dbValue);
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
