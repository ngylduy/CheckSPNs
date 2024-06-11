﻿using CheckSPNs.Data.Abstract;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Data
{
    public class DapperHelper<T> : IDapperHelper<T> where T : class
    {

        private readonly string connectString = string.Empty;

        public DapperHelper(IConfiguration configuration)
        {
            connectString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task ExecuteNotReturnAsync(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                await dbConnection.ExecuteAsync(query, parammeters, commandType: CommandType.Text);
            }
        }

        public async Task<T> ExecuteReturnScalarAsync<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parammeters,
                                                                commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> ExecuteSqlReturnListAsync<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnListAsync<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
