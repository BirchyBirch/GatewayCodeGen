using Headspring;

namespace Birchy.GatewayCodeGen.Core.Database
{
    public class SqlDataType : Enumeration<SqlDataType, string>
    {
        //Strings
        public static readonly SqlDataType NVarchar = new SqlDataType("nvarchar", "string", "string");
        public static readonly SqlDataType NChar = new SqlDataType("nchar", "unicode character string", "string");
        public static readonly SqlDataType Varchar = new SqlDataType("varchar", "string", "string");
        public static readonly SqlDataType Char = new SqlDataType("char", "characters", "string");        
        public static readonly SqlDataType Text = new SqlDataType("text", "Text", "string");
        public static readonly SqlDataType NText = new SqlDataType("ntext", "Unicode Text", "string");

        //Date and Time
        public static readonly SqlDataType DateTime = new SqlDataType("datetime", "DateTime", "DateTime");
        public static readonly SqlDataType Date = new SqlDataType("date", "Date", "DateTime");
        public static readonly SqlDataType DateTime2 = new SqlDataType("datetime2", "DateTime2", "DateTime");
        public static readonly SqlDataType SmallDateTime = new SqlDataType("smalldatetime", "Small DateTime", "DateTime");
        public static readonly SqlDataType DateTimeOffset = new SqlDataType("datetimeoffset", "DateTime Offset", "DateTime");
        public static readonly SqlDataType Time = new SqlDataType("time", "Time", "DateTime");

        //Binary strings
        public static readonly SqlDataType Binary = new SqlDataType("binary", "binary string", "byte[]");
        public static readonly SqlDataType VarBinary = new SqlDataType("varbinary", "variable length binary string", "byte[]");
        public static readonly SqlDataType Image = new SqlDataType("image", "image (binary)", "byte[]");
        
        //Numerics
        public static readonly SqlDataType BigInt = new SqlDataType("bigint", "long", "long");
        public static readonly SqlDataType Boolean = new SqlDataType("bit", "bool", "bool");
        public static readonly SqlDataType Decimal = new SqlDataType("decimal", "decimal", "decimal");
        public static readonly SqlDataType Integer = new SqlDataType("int", "int", "int");
        public static readonly SqlDataType Money = new SqlDataType("money","Money","decimal");
        public static readonly SqlDataType Numeric = new SqlDataType("numeric","Numeric","decimal" );
        public static readonly SqlDataType SmallInt = new SqlDataType("smallint", "Small Int", "int");
        public static readonly SqlDataType SmallMoney = new SqlDataType("smallmoney","Small Money","decimal");
        public static readonly SqlDataType TinyInt = new SqlDataType("tinyint","Tiny Int","byte");
        
        //Approximate numerics
        public static readonly SqlDataType Float = new SqlDataType("float", "Float", "double");
        public static readonly SqlDataType Real = new SqlDataType("real", "Real", "double");

        //Other types
        public static readonly SqlDataType UniqueIdentifier = new SqlDataType("uniqueidentifier","Unique Identifier","Guid");

        public SqlDataType(string value, string displayName, string cSharpType,bool isSupported= true) : base(value, displayName)
        {
            CSharpType = cSharpType;
        }

        public string CSharpType { get; }
    }
}