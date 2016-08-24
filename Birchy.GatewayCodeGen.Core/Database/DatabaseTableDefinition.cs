namespace Birchy.GatewayCodeGen.Core.Database
{
    public class DatabaseTableDefinition
    {
        public string SchemaName { get; set; }
        public string FormattedName => Name.ToPascalCase();
        public string Name { get; set; }
        public string QualifiedName => $"{SchemaName}.{Name}";
        public long ObjectId { get; set; }

        public string DtoName => $"{FormattedName}Dto";

        public DatabaseColumnDefinition[] Columns { get; set; }
    }
}