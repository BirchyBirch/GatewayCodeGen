using Birchy.GatewayCodeGen.Console.Core;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Console
{
    internal class Program
    {
        private static void Main()
        {
            var dtog = new DataTransferObjectGenerator();
            var databaseTableDefinition = new DatabaseTableDefinition
            {
                Name = "Foobar",
                Columns = new[]
                {
                    new DatabaseColumnDefinition
                    {
                        SqlDataType = SqlDataType.NVarchar,
                        IsIdentity = false,
                        IsNullable = true,
                        Name = "Name"
                    },
                    new DatabaseColumnDefinition
                    {
                        SqlDataType = SqlDataType.Decimal,
                        IsIdentity = false,
                        IsNullable = true,
                        Name = "HeightInInches"
                    }
                }
            };
            var codeGenerationConfiguration = new CodeGenerationConfiguration
            {
                CoreNamespace = "Birchy.Core"
            };
            var generate = dtog.GenerateCode(codeGenerationConfiguration, databaseTableDefinition);
            System.Console.WriteLine(generate);
        }
    }
}