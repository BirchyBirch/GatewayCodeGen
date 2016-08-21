using Headspring;

namespace Birchy.GatewayCodeGen.Core.Database
{
    public class SqlDataType : Enumeration<SqlDataType, string>
    {
        public static readonly SqlDataType NVarchar = new SqlDataType("nvarchar", "string", "string");
        public static readonly SqlDataType Varchar = new SqlDataType("varchar", "string", "string");
        public static readonly SqlDataType Integer = new SqlDataType("int", "int", "int");
        public static readonly SqlDataType Decimal = new SqlDataType("decimal", "decimal", "decimal");

        public SqlDataType(string value, string displayName, string cSharpType) : base(value, displayName)
        {
            CSharpType = cSharpType;
        }

        public string CSharpType { get; }
    }
}