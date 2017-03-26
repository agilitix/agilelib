using System.Collections.Generic;
using System.Data;
using Dapper;
using Sybase.Data.AseClient;

namespace AxSybase.Dapper
{
    public class AseCommandParameters : List<AseParameter>, SqlMapper.IDynamicParameters
    {
        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            foreach (AseParameter parameter in this)
            {
                command.Parameters.Add(parameter);
            }
        }
    }
}
