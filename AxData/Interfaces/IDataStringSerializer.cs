using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AxData.Interfaces
{
    public interface IDataStringSerializer<TData> : IDataSerializer<TData, string> where TData : class
    {
    }
}
