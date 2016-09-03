using System;
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
            var columnInfoGateway = ColumnInfoGatewayFactory(configuration);
            var tableInfoGateway = TableInfoGatewayFactory(configuration);
            var tableInfoDtos = tableInfoGateway.GetAll();
            var columnDtos = columnInfoGateway.GetAll();
            var columnDtoses = columnDtos.GroupBy(g => g.ObjectId)
                .ToDictionary(k => k.Key, v => v.Select(s => s).ToArray());
            var relevantTables = tableInfoDtos
                .Where(d => SchemaNotExcluded(configuration, d) && TableIsIncluded(configuration, d))
                .ToArray();
            var tableDefinitions = new List<DatabaseTableDefinition>();
            foreach (var relevantTable in relevantTables)
                tableDefinitions.Add(new DatabaseTableDefinition(relevantTable, columnDtoses));
            return tableDefinitions.ToArray();
        }

        private static ITableInfoGateway TableInfoGatewayFactory(CodeGenerationConfiguration configuration)
        {
            return new TableInfoGateway(configuration.ConnectionString);
        }

        private static IColumnInfoGateway ColumnInfoGatewayFactory(CodeGenerationConfiguration configuration)
        {
            return new ColumnInfoGateway(configuration.ConnectionString);
        }


        private static bool TableIsIncluded(CodeGenerationConfiguration configuration, TableInfoDto d)
        {
            return (configuration?.IncludeTables?.Contains(d.Name, StringComparer.OrdinalIgnoreCase) ?? true) ||
                   (configuration.IncludeTables.Length == 0);
        }

        private static bool SchemaNotExcluded(CodeGenerationConfiguration configuration, TableInfoDto d)
        {
            return (!configuration?.ExcludeSchemas?.Contains(d.SchemaName, StringComparer.OrdinalIgnoreCase) ??
                    true) ||
                   (configuration.ExcludeSchemas.Length == 0);
        }
    }
}