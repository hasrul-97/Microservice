using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManager.Abstraction.Repository;

namespace TenantManager.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private static string _connectionString = string.Empty;

        public RepositoryManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionString").Value;
        }
        public async Task<int> AddToDatabase(string sqlQuery)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<T> FetchData<T>(string sqlQuery)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    var result = (await _sqlConnection.QueryAsync<T>(sqlQuery)).ToList();
                    if (result.Count > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        return default;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<T> FetchDataWithParameter<T>(string sqlQuery, object parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    var result = (await _sqlConnection.QueryAsync<T>(sqlQuery, parameter)).ToList();
                    if (result.Count > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        return default;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> AddToDatabaseWithParameter(string sqlQuery, object parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery, parameter);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> Delete(string sqlQuery)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> DeleteWithParameter(string sqlQuery, object parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery, parameter);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<List<T>> FetchList<T>(string sqlQuery)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    List<T> result = (await _sqlConnection.QueryAsync<T>(sqlQuery)).ToList();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<List<T>> FetchListWithParameter<T>(string sqlQuery, object parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    List<T> result = (await _sqlConnection.QueryAsync<T>(sqlQuery, parameter)).ToList();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> Update(string sqlQuery)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> UpdateWithParameter(string sqlQuery, object parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery, parameter);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public async Task<int> AddToDatabaseBulkWithParameter<T>(string sqlQuery, List<T> parameter)
        {
            using (NpgsqlConnection _sqlConnection = new NpgsqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                try
                {
                    int numberOfRowsAffected = await _sqlConnection.ExecuteAsync(sqlQuery, parameter);
                    return numberOfRowsAffected;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }
    }
}
