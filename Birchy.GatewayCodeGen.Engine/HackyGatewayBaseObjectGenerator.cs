using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Engine
{
    public class HackyGatewayBaseObjectGenerator : IGatewayBaseObjectGenerator
    {
        public string GenerateGatewayBaseObject(CodeGenerationConfiguration configuration)
        {
            string template = @"using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace {0}
{{
    public abstract class GatewayBase
    {{
        private readonly string _connectionString;

        protected GatewayBase(string connectionString)
        {{
            _connectionString = connectionString;
        }}

        private SqlConnection ConnectionFactory()
        {{
            return new SqlConnection(_connectionString);
        }}

        protected T[] GetFromDatabase<T>(string sql, object param)
        {{
            T[] data;
            using (var connection = ConnectionFactory())
            {{
                connection.Open();
                data = connection.Query<T>(sql, param).ToArray();
                connection.Close();
            }}
            return data;
        }}

        protected int AddToDatabase(string sql, object param)
        {{
            int rowCount;
            using (var connection = ConnectionFactory())
            {{
                connection.Open();
                using (IDbTransaction transAction = connection.BeginTransaction())
                {{
                    rowCount = connection.Execute(sql, param, transAction);
                    transAction.Commit();
                    connection.Close();
                }}
            }}
            return rowCount;
        }}
    }}
}}";
            return string.Format(template, configuration.DataNamespace);
        }
    }
}