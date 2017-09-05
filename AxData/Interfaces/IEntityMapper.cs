using System.Collections.Generic;
using System.Data;

namespace AxData.Interfaces
{
    public interface IEntityMapper<TEntity> where TEntity : class, new()
    {
        TEntity Map(DataRow dataRow);
        IEnumerable<TEntity> Map(DataTable dataTable);

        DataRow Map(TEntity entity);
        DataTable Map(IEnumerable<TEntity> entities);
    }
}
