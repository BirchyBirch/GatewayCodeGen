using System.Xml.Linq;
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
            var codeGenerationRepository = GetCodeGenerationRepository();
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

        private static CodeGenerationRepository GetCodeGenerationRepository()
        {
            return new CodeGenerationRepository(
                new DatabaseTableInfoRepository(),
                new DataTransferObjectGenerator(),
                new HackyGatewayBaseObjectGenerator(),
                new HackyGatewayGenerator(new SqlGenerator()),
                new SqlGenerator());
        }

        [Fact]
        public void GenerateDataAccessLayer_MakesTheDataAccessLayer()
        {
            var codeGenerationRepository = GetCodeGenerationRepository();
            var generatedDataAccessLayer = codeGenerationRepository.GenerateDataAccessLayer(new CodeGenerationConfiguration
            {
                ConnectionString = new LocalDatabaseSettings().ConnectionString,
                DatabaseName = "CardShop",
                CoreNamespace = "CardShop.Core",
                DataNamespace = "CardShop.Data",
            });
            Assert.NotNull(generatedDataAccessLayer);
        }

    }
}