using Dapper;
using FMS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FMS.Repository
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T, P>(string spName, P Parameters)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
                {
                    connection.Open();
                    var entities = await connection.QueryAsync<T>(spName, Parameters, commandType: CommandType.StoredProcedure);
                    return entities;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetByIdAsync<T, P>(string spName, P Parameters)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            return await connection.QueryAsync<T>(spName, Parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IncomeReponce> UpsertAsync<T>(string spName, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            var result = await connection.QuerySingleOrDefaultAsync<IncomeReponce>(spName, parameters, commandType: CommandType.StoredProcedure);

            var resultSQLReponce = new IncomeReponce
            {
                Id = result?.Id ?? 0,
                No = result?.No ?? "Unknown",
                Msg = result?.Msg ?? "Unknown"
            };

            return resultSQLReponce;
        }
    }
}