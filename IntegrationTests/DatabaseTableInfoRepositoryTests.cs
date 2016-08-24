using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Repository;
using Xunit;

namespace IntegrationTests
{
    public class DatabaseTableInfoRepositoryTests
    {
        [Fact]
        public void GetDefinitions_GetsTheDefinitions()
        {
            var databaseTableInfoRepository = new DatabaseTableInfoRepository();
            var databaseTableDefinitions = databaseTableInfoRepository.GetDefinitions(new CodeGenerationConfiguration
            {
                ConnectionString = new LocalDatabaseSettings().ConnectionString,
            });
            Assert.True(databaseTableDefinitions.Length>4);
        }

    }
}
