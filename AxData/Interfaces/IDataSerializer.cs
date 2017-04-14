using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AxData.Interfaces
{
    public interface IDataSerializer<TData, TOut> where TData : class where TOut : class
    {
        TOut Serialize(TData data);
        TData Deserialize(TOut serialized);
    }
}
