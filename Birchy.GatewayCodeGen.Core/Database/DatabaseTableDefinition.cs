using System.Collections.Generic;
using System.Linq;

namespace Birchy.GatewayCodeGen.Core.Database
{
    public class DatabaseTableDefinition
    {
        public DatabaseTableDefinition()
        {
            
        }
        public string SchemaName { get; set; }
        public string FormattedName => Name.ToPascalCase();
        public string Name { get; set; }
        public string QualifiedName => $"{SchemaName}.{Name}";
        public long ObjectId { get; set; }

        public string DtoName => $"{FormattedName}Dto";

        public DatabaseTableDefinition(TableInfoDto relevantTable, Dictionary<long, ColumnDto[]> columnDtoses)
        {
            Name = relevantTable.Name;
            ObjectId = relevantTable.ObjectId;
            SchemaName = relevantTable.SchemaName;
            Columns = columnDtoses[relevantTable.ObjectId].Select(s => new DatabaseColumnDefinition
            {
                Name = s.Name,
                SqlDataType = SqlDataType.FromValue(s.SqlDataType),
                IsIdentity = s.IsIdentity,
                IsNullable = s.IsNullable
            }).ToArray();
        }

        public DatabaseColumnDefinition[] Columns { get; set; }
    }
}