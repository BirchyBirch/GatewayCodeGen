using Xunit;

namespace UnitTests.Engine
{
    public class GatewayBaseObjectGeneratorTests : IClassFixture<GatewayBaseObjectGeneratorTestFixture>
    {
        public GatewayBaseObjectGeneratorTests(GatewayBaseObjectGeneratorTestFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly GatewayBaseObjectGeneratorTestFixture _fixture;

        [Fact]
        public void Constructor_CreatesInstance()
        {
            Assert.NotNull(_fixture.Instance);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatePrivateSettingsField()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains("protected readonly IDatabaseSettings DatabaseSettings;", createdSource);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatesClassDeclaration()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains($"public abstract class {_fixture.ConfigurationUsed.DalBaseClassName}", createdSource);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatesConstructorDeclaration()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains(
                $"protected {_fixture.ConfigurationUsed.DalBaseClassName}(IDatabaseSettings databaseSettings)",
                createdSource);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatesNamespaceDeclaration()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains($"namespace {_fixture.ConfigurationUsed.DataNamespace}", createdSource);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatesUsingDeclarations()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains("using Dapper;", createdSource);
            Assert.Contains("using System.Data.SqlClient;", createdSource);
            Assert.Contains("using System.Data;", createdSource);
            Assert.Contains("using System.Linq;", createdSource);
        }

        [Fact]
        public void GenerateGatewayBaseObject_CreatesGetFromDatabaseMethod()
        {
            var createdSource = _fixture.ResultOfCreateGatewayBaseObject;
            Assert.Contains("protected T[] GetManyFromDatabase<T>(string sql, object param)",createdSource);
        }

    }

    //public abstract class GatewayBaseExample
    //{
    //    private readonly IDatabaseSettings _settings;

    //    protected GatewayBaseExample(IDatabaseSettings settings)
    //    {
    //        _settings = settings;
    //    }

    //    private SqlConnection ConnectionFactory()
    //    {
    //        return new SqlConnection(_settings.DBName);
    //    }

    //    protected T[] GetFromDatabase<T>(string sql, object param)
    //    {
    //        T[] data;
    //        using (var connection = ConnectionFactory())
    //        {
    //            connection.Open();
    //            data = connection.Query<T>(sql, param).ToArray();
    //            connection.Close();
    //        }
    //        return data;
    //    }
    //}

    //public interface IDatabaseSettings
    //{
    //    string DBName { get; }
    //}
}