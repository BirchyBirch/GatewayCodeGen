using Birchy.GatewayCodeGen.Data;
using FluentAssertions;
using Xunit;

namespace IntegrationTests
{
    public class TableInfoGatewayTests
    {
        private static TableInfoGateway GetTableInfoGateway()
        {
            return new TableInfoGateway(new LocalDatabaseSettings());
        }


        public static object[][] TablesDataObjects => new object[][]
        {
            new[] {"Version", "RoundhousE"},
            new[] {"ScriptsRun", "RoundhousE"},
            new[] {"ScriptsRunErrors", "RoundhousE"},
            new[] {"Customer", "RoundhousE"},
            new[] {"HistoricalAddresses", "RoundhousE"}
        };

        [Theory]
        [MemberData(nameof(TablesDataObjects))]
        public void GetAll_GetsCorrectData(string name, string schema)
        {
            var tableInfoGateway = GetTableInfoGateway();
            var tableInfoDtos = tableInfoGateway.GetAll();
            tableInfoDtos.Should().Contain(t => t.Name == name,"It's in the system table");
            tableInfoDtos.Should().Contain(t => t.SchemaName == schema, "It's in the system table");
            tableInfoDtos.Should().Contain(s => s.ObjectId > 2);
        }

        [Fact]
        public void Constructor_CanCreate()
        {
            Assert.NotNull(GetTableInfoGateway());
        }
    }
}