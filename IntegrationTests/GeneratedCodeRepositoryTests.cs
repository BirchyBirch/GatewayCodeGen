using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Engine;
using Birchy.GatewayCodeGen.Engine.SQL;
using Birchy.GatewayCodeGen.Repository;
using Xunit;

namespace IntegrationTests
{
    public class CodeGenerationRepositoryTests
    {
        [Fact]
        public void GenerateCode_MakesTheCode()
        {
            var codeGenerationRepository = new CodeGenerationRepository(new DatabaseTableInfoRepository(), new DataTransferObjectGenerator(),
                new SqlGenerator());
            var generatedCodes = codeGenerationRepository.GenerateCode(new CodeGenerationConfiguration
            {
                ConnectionString = new LocalDatabaseSettings().ConnectionString,
                DatabaseName = "CardShop",

                CoreNamespace = "CardShop.Core",
                ShouldMakeDtos = true,
                ShouldMakeSql = true
            });
            Assert.Equal(5, generatedCodes.Length);
        }

    }
}