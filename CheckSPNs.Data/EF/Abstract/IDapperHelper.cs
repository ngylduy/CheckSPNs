using Dapper;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IDapperHelper
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
