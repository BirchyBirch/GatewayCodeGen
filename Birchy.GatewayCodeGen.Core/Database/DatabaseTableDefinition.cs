namespace Birchy.GatewayCodeGen.Core.Database
{
    public class DatabaseTableDefinition
    {
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string QualifiedName => $"{SchemaName}.{Name}";
        public long ObjectId { get; set; }

        public string DtoName => $"{Name}Dto";

        public DatabaseColumnDefinition[] Columns { get; set; }
    }
}