using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AxData.Interfaces
{
    public interface IDataSerializer<TData, TSerialized>
        where TData : class
        where TSerialized : class
    {
        TSerialized Serialize(TData data);
        TData Deserialize(TSerialized serialized);
    }
}
