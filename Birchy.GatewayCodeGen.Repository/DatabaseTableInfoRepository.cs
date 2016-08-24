using System.Collections.Generic;
using System.Linq;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;
using Birchy.GatewayCodeGen.Data;

namespace Birchy.GatewayCodeGen.Repository
{
    public class DatabaseTableInfoRepository : IDatabaseTableInfoRepository
    {
        public DatabaseTableDefinition[] GetDefinitions(CodeGenerationConfiguration configuration)
        {
            var columnInfoGateway = new ColumnInfoGateway(configuration.ConnectionString);
            var tableInfoGateway = new TableInfoGateway(configuration.ConnectionString);
            var tableInfoDtos = tableInfoGateway.GetAll();
            var columnDtos = columnInfoGateway.GetAll();
            var columnDtoses = columnDtos.GroupBy(g => g.ObjectId)
                .ToDictionary(k => k.Key, v => v.Select(s => s).ToArray());
            var relevantTables = tableInfoDtos
                .Where(
                    d =>
                        (!configuration?.ExcludeSchemas?.Contains(d.SchemaName) ?? true) ||
                        (configuration.ExcludeSchemas.Length == 0))
                .Where(d => (configuration?.IncludeTables?.Contains(d.Name) ?? true)||(configuration.IncludeTables.Length==0))
                .ToArray();
            var tableDefinitions = new List<DatabaseTableDefinition>();
            foreach (var relevantTable in relevantTables)
                tableDefinitions.Add(new DatabaseTableDefinition
                {
                    Name = relevantTable.Name,
                    ObjectId = relevantTable.ObjectId,
                    SchemaName = relevantTable.SchemaName,
                    Columns = columnDtoses[relevantTable.ObjectId].Select(s => new DatabaseColumnDefinition
                    {
                        Name = s.Name,
                        SqlDataType = SqlDataType.FromValue(s.SqlDataType),
                        IsIdentity = s.IsIdentity,
                        IsNullable = s.IsNullable
                    }).ToArray()
                });
            return tableDefinitions.ToArray();
        }
    }
}