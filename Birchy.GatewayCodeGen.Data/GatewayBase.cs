using System.Data.SqlClient;
using System.Linq;
using Birchy.GatewayCodeGen.Contracts;
using Dapper;

namespace Birchy.GatewayCodeGen.Data
{
    public abstract class GatewayBase
    {
        private readonly string _connectionString;

        protected GatewayBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection ConnectionFactory()
        {
            return new SqlConnection(_connectionString);
        }

        protected T[] GetFromDatabase<T>(string sql, object param)
        {
            T[] data;
            using (var connection = ConnectionFactory())
            {
                connection.Open();
                data = connection.Query<T>(sql, param).ToArray();
                connection.Close();
            }
            return data;
        }
    }
}
