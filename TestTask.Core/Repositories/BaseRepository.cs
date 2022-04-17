using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestTask.Core.Repositories
{
    public class BaseRepository
    {
       
        private string connectionString;
        public BaseRepository(IBaseDbConfiguration configuration)
        {
           
            connectionString = configuration.ConnectionString;

        }
        public async Task<T> QueryFirstAsync<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.QueryFirstAsync<T>(query, parameters).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; 
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.QueryFirstAsync<T>(query, parameters).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; 
            }
        }

        public async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.QuerySingleAsync<T>(query, parameters).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; 
            }
        }
        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.QuerySingleOrDefaultAsync<T>(query, parameters).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; 
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.QueryAsync<T>(query, parameters).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default;
            }
        }
        public async Task<int> ExecuteAsync(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(connectionString))
                {
                    return await conn.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
