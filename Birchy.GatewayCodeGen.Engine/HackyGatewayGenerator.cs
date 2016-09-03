using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Engine
{
    public class HackyGatewayGenerator : IGatewayGenerator
    {
        private readonly ISqlGenerator _sqlGenerator;

        public HackyGatewayGenerator(ISqlGenerator sqlGenerator)
        {
            _sqlGenerator = sqlGenerator;
        }

        public string GenerateGatewayClass(CodeGenerationConfiguration configuration, DatabaseTableDefinition tableDefinition)
        {
            var insertStatement = _sqlGenerator.GenerateInsert(tableDefinition);
            var selectStatement = _sqlGenerator.GenerateSelect(tableDefinition);
            const string template = @"using {0};

namespace {1}
{{
    public class {2}DataGateway : GatewayBase
    {{
        public {2}DataGateway(string connectionString) : base(connectionString)
        {{
        }}

        public {3}[] GetAll()
        {{
            const string sql = @""{4}"";
            return GetFromDatabase<{3}>(sql, null);
        }}

        public int AddItems({3}[] dtos)
        {{
            const string sql = @""{5}"";
            return AddToDatabase(sql, dtos);
        }}
    }}    
}}";
            return string.Format(template, configuration.CoreNamespace,configuration.DataNamespace, tableDefinition.FormattedName,tableDefinition.DtoName,selectStatement,insertStatement);
        }
    }
}