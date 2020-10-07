using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Repository.Context
{
    public class DapperContext
    {
        protected string ConnectionString { get; }

        public DapperContext(IConfiguration configuration)
        {
            ConnectionString = configuration["SqlServerConnection:SqlServerConnectionString"];
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}