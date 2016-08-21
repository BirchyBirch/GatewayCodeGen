using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;
using Birchy.GatewayCodeGen.Engine;
using Xunit;

namespace UnitTests.Engine
{
    public class DataTransferObjectGeneratorTests
    {
        private static DataTransferObjectGenerator GetGenerator()
        {
            return new DataTransferObjectGenerator();
        }

        [Fact]
        public void Constructor_CreatesNewInstance()
        {
            Assert.NotNull(GetGenerator());            
        }

        [Fact]
        public void GenerateCode_CreatesCorrectDtoSourceCode()
        {
            var dataTransferObjectGenerator = GetGenerator();
            var codeGenerationConfiguration = new CodeGenerationConfiguration {CoreNamespace = "Birchy.Core"};
            var databaseTableDefinition = new DatabaseTableDefinition
            {
                Name = "TestTable",
                ObjectId = 101,
                SchemaName = "dbo",
                Columns = new[]
                {
                    new DatabaseColumnDefinition
                    {
                        Name = "FooId",
                        IsIdentity = true,
                        IsNullable = true,
                        SqlDataType = SqlDataType.Integer
                    },
                    new DatabaseColumnDefinition
                    {
                        Name = "BarId",
                        IsIdentity = false,
                        IsNullable = false,
                        SqlDataType = SqlDataType.Integer
                    },
                    new DatabaseColumnDefinition
                    {
                        Name = "BazName",
                        SqlDataType = SqlDataType.NVarchar,
                        IsNullable = true,
                        IsIdentity = false
                    },
                    new DatabaseColumnDefinition
                    {
                        Name = "BirchyWeight",
                        SqlDataType = SqlDataType.Decimal,
                        IsIdentity = false,
                        IsNullable = true
                    }
                }
            };
            var generateCode = dataTransferObjectGenerator.GenerateCode(codeGenerationConfiguration, databaseTableDefinition);
            Assert.Contains("public class TestTableDto",generateCode);
            Assert.Contains("public int? FooId", generateCode);
            Assert.Contains("public int BarId", generateCode);
            Assert.Contains("public string BazName", generateCode);
            Assert.Contains("public decimal? BirchyWeight", generateCode);
            Assert.Contains("namespace Birchy.Core", generateCode);
        }
    }
}