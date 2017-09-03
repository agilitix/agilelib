using System.Collections.Generic;
using System.Data;

namespace AxData.Interfaces
{
    public interface IEntityMapper<out TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> Map(DataTable dataTable);
    }
}
