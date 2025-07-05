using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Common.Extensions
{
    public static class SqlParameterExtensions
{
    public static string ObtenerCadenaParamSQL(this IEnumerable<SqlParameter> parametros)
    {
        return string.Join(", ", parametros.Select(p => p.ParameterName));
    }
}
}