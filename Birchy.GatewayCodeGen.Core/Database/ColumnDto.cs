namespace Birchy.GatewayCodeGen.Core.Database
{
    public class ColumnDto
    {
        public long ObjectId { get; }
        public string Name { get; }
        public string SqlDataType { get; }
        public bool IsNullable { get; }
        public bool IsIdentity { get; }
    }    
}