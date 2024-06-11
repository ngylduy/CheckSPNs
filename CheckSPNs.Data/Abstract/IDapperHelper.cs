using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Data.Abstract
{
    public interface IDapperHelper<T> where T : class
    {
        /// <summary>
        /// Execute raw query and not return any value
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        Task ExecuteNotReturnAsync(string query, DynamicParameters parammeters = null);
        Task<T> ExecuteReturnScalarAsync<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> ExecuteSqlReturnListAsync<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> ExecuteStoreProcedureReturnListAsync<T>(string query, DynamicParameters parammeters = null);
    }
}
