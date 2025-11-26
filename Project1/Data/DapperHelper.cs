using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Project1.Data
{
    public class DapperHelper
    {
        private readonly string _conn;
        public DapperHelper(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<T> Query<T>(string proc, object? param = null)
        {
            using var con = new SqlConnection(_conn);
            return con.Query<T>(proc, param, commandType: CommandType.StoredProcedure);
        }

        public int Execute(string proc, object? param = null)
        {
            using var con = new SqlConnection(_conn);
            return con.Execute(proc, param, commandType: CommandType.StoredProcedure);
        }
    }
}
