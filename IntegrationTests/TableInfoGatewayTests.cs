using Birchy.GatewayCodeGen.Core.Database;
using Birchy.GatewayCodeGen.Data;
using FluentAssertions;
using Xunit;

namespace IntegrationTests
{
    public class TableInfoGatewayTests
    {
        private static TableInfoGateway GetTableInfoGateway()
        {
            return new TableInfoGateway(new LocalDatabaseSettings().ConnectionString);
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
            tableInfoDtos.Should().Contain(t => t.Name == name, "It's in the system table");
            tableInfoDtos.Should().Contain(t => t.SchemaName == schema, "It's in the system table");
            tableInfoDtos.Should().Contain(s => s.ObjectId > 2);
        }

        [Fact]
        public void Constructor_CanCreate()
        {
            Assert.NotNull(GetTableInfoGateway());
        }
    }

    public class ColumnInfoGatewayTests : IClassFixture<ColumnInfoGatewayFixture>
    {
        private readonly ColumnInfoGatewayFixture _fixture;

        public ColumnInfoGatewayTests(ColumnInfoGatewayFixture fixture)
        {
            _fixture = fixture;
        }

        public static object[][] ColumnsDataObjects => new[]
        {
            new object[] {565577053L, "id", "bigint", false, true},
            new object[] {565577053L, "repository_path", "nvarchar", true, false},
            new object[] {565577053L, "version", "nvarchar", true, false},
            new object[] {565577053L, "entry_date", "datetime", true, false},
            new object[] {565577053L, "modified_date", "datetime", true, false},
            new object[] {565577053L, "entered_by", "nvarchar", true, false},
            new object[] {597577167L, "id", "bigint", false, true},
            new object[] {597577167L, "version_id", "bigint", true, false},
            new object[] {597577167L, "script_name", "nvarchar", true, false},
            new object[] {597577167L, "text_of_script", "text", true, false},
            new object[] {597577167L, "text_hash", "nvarchar", true, false},
            new object[] {597577167L, "one_time_script", "bit", true, false},
            new object[] {597577167L, "entry_date", "datetime", true, false},
            new object[] {597577167L, "modified_date", "datetime", true, false},
            new object[] {597577167L, "entered_by", "nvarchar", true, false},
            new object[] {629577281L, "id", "bigint", false, true},
            new object[] {629577281L, "repository_path", "nvarchar", true, false},
            new object[] {629577281L, "version", "nvarchar", true, false},
            new object[] {629577281L, "script_name", "nvarchar", true, false},
            new object[] {629577281L, "text_of_script", "ntext", true, false},
            new object[] {629577281L, "erroneous_part_of_script", "ntext", true, false},
            new object[] {629577281L, "error_message", "ntext", true, false},
            new object[] {629577281L, "entry_date", "datetime", true, false},
            new object[] {629577281L, "modified_date", "datetime", true, false},
            new object[] {629577281L, "entered_by", "nvarchar", true, false},
            new object[] {661577395L, "CustomerId", "bigint", false, true},
            new object[] {661577395L, "FirstName", "nvarchar", false, false},
            new object[] {661577395L, "LastName", "nvarchar", false, false},
            new object[] {661577395L, "MiddleInitial", "nvarchar", true, false},
            new object[] {661577395L, "Tile", "nvarchar", true, false},
            new object[] {661577395L, "Birthdate", "datetime", false, false},
            new object[] {661577395L, "ActiveEmailAddress", "nvarchar", true, false},
            new object[] {693577509L, "HistoricalAdresseslId", "int", false, true},
            new object[] {693577509L, "CustomerId", "bigint", false, false},
            new object[] {693577509L, "LineOne", "nvarchar", false, false},
            new object[] {693577509L, "LineTwo", "nvarchar", true, false},
            new object[] {693577509L, "City", "nvarchar", false, false},
            new object[] {693577509L, "State", "nvarchar", true, false},
            new object[] {693577509L, "DateAdded", "datetime", false, false},
            new object[] {693577509L, "DateInvalidated", "datetime", true, false},
            new object[] {693577509L, "IsActive", "bit", false, false}
        };

        [Theory]
        [MemberData(nameof(ColumnsDataObjects))]
        public void GetAll_GetsCorrectData(long objectId, string name, string sqlDataType, bool isNullalbe,
            bool isIdentity)
        {
            _fixture.ResultOfGetAll.Should()
                .Contain(
                    t =>
                        (t.SqlDataType == sqlDataType) && (t.IsNullable == isNullalbe) &&
                        (t.IsIdentity == isIdentity) && (t.Name == name));
        }
    }

    public class ColumnInfoGatewayFixture
    {
        public ColumnInfoGatewayFixture()
        {
            ResultOfGetAll = new ColumnInfoGateway(new LocalDatabaseSettings().ConnectionString).GetAll();
        }

        public ColumnDto[] ResultOfGetAll { get; }
    }
}