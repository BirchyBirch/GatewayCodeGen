using Headspring;

namespace Birchy.GatewayCodeGen.Core.Database
{
    public class SqlDataType : Enumeration<SqlDataType, string>
    {
        public static readonly SqlDataType NVarchar = new SqlDataType("nvarchar", "string", "string");
        public static readonly SqlDataType Varchar = new SqlDataType("varchar", "string", "string");
        public static readonly SqlDataType Integer = new SqlDataType("int", "int", "int");
        public static readonly SqlDataType Decimal = new SqlDataType("decimal", "decimal", "decimal");
        public static readonly SqlDataType BigInt = new SqlDataType("bigint", "long", "long");
        public static readonly SqlDataType DateTime = new SqlDataType("datetime", "DateTime", "DateTime");
        public static readonly SqlDataType Text = new SqlDataType("text", "string", "string");
        public static readonly SqlDataType NText = new SqlDataType("ntext", "string", "string");
        public static readonly SqlDataType Boolean = new SqlDataType("bit", "bool", "bool");

        public SqlDataType(string value, string displayName, string cSharpType) : base(value, displayName)
        {
            CSharpType = cSharpType;
        }

        public string CSharpType { get; }
    }
}