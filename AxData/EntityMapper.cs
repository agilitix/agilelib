using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using AxData.Interfaces;
using AxExtensions;
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
                    field.SetValue(entity, value.ConvertTo(field.FieldType));
                }
            }

            return entity;
        }
    }
}
