using System.Data.SqlClient;
using System.Linq;
using Birchy.GatewayCodeGen.Contracts;
using Dapper;

namespace Birchy.GatewayCodeGen.Data
{
    public abstract class GatewayBase
    {
        private readonly IDatabaseSettings _settings;

        protected GatewayBase(IDatabaseSettings settings)
        {
            _settings = settings;
        }

        private SqlConnection ConnectionFactory()
        {
            return new SqlConnection(_settings.ConnectionString);
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
