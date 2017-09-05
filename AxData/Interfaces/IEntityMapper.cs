using System.Collections.Generic;
using System.Data;

namespace AxData.Interfaces
{
    public interface IEntityMapper<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> Map(DataTable dataTable);
        DataTable Map(IEnumerable<TEntity> entities);
    }
}
