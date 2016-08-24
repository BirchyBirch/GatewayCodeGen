using System;
using System.Linq;
using System.Text;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Engine.SQL
{
    public class SqlGenerator : ISqlGenerator
    {
        public string GenerateSelect(DatabaseTableDefinition tableDefitition)
        {
            var select =
                new StringBuilder(
                    $"SELECT [{tableDefitition.Columns[0].Name}] AS [{tableDefitition.Columns[0].FormattedName}]\r\n");
            foreach (var databaseColumnDefinition in tableDefitition.Columns.Skip(1))
                select.AppendLine(
                    $"    ,[{databaseColumnDefinition.Name}] AS [{databaseColumnDefinition.FormattedName}] ");
            string from = $"FROM   [{tableDefitition.SchemaName}].[{tableDefitition.Name}]";
            return select + from;
        }

        public string GenerateInsert(DatabaseTableDefinition tableDefitition)
        {
            string insert = $"INSERT INTO [{tableDefitition.SchemaName}].[{tableDefitition.Name}]";
            var nonIdentityColumns = tableDefitition.Columns.Where(n => !n.IsIdentity).ToArray();
            var formattedColumnNames = nonIdentityColumns.Select(s => $"[{s.Name}]");
            string columnDef = $"({string.Join(",", formattedColumnNames)})";
            string values = "VALUES";
            string dtoColumns = $"({string.Join(",", nonIdentityColumns.Select(s => $"@{s.FormattedName}"))})";
            return $"{insert}{Environment.NewLine}{columnDef}\r\n{values}\r\n{dtoColumns}";

        }
    }
}