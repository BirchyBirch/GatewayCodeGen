using System;
using System.Linq;
using System.Text.RegularExpressions;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;
using Birchy.GatewayCodeGen.Engine.SQL;
using Ploeh.AutoFixture;
using Xunit;


namespace UnitTests.Engine
{
    public class SqlGeneratorTests
    {
        private SqlGenerator GetGenerator()
        {
            return new SqlGenerator();
        }

        [Fact]
        public void GenerateInsert_GeneratesTheCorrectStatement()
        {
            var fixture = new Fixture();
            var databaseColumnDefinitions = fixture.CreateMany<DatabaseColumnDefinition>(5).ToArray();
            var firstColumn = databaseColumnDefinitions.First();
            firstColumn.IsIdentity = true;
            databaseColumnDefinitions.Except(new[] {firstColumn}).ToList().ForEach(f => f.IsIdentity = false);
            var databaseTableDefinition = fixture.Create<DatabaseTableDefinition>();
            databaseTableDefinition.Columns = databaseColumnDefinitions;
            var generateInsert = GetGenerator().GenerateInsert(databaseTableDefinition);
            var splitInsert = generateInsert.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            var columnsLine = splitInsert[1].Split(',');
            var valuesLine = splitInsert[3].Split(',');
            for (var i = 0; i < columnsLine.Length; i++)
                Assert.Contains(columnsLine[i].ToSlug().Replace("-", ""), valuesLine[i].ToSlug());
        }

        [Fact]
        public void GenerateSelect_CreatesTheCorrectStatement()
        {
            var fixture = new Fixture();
            var databaseColumnDefinitions = fixture.CreateMany<DatabaseColumnDefinition>(5).ToArray();
            var databaseTableDefinition = fixture.Create<DatabaseTableDefinition>();
            databaseTableDefinition.Columns = databaseColumnDefinitions;
            var generateSql = GetGenerator().GenerateSelect(databaseTableDefinition);
            var r =
                new Regex(
                    @"SELECT\s(\[[\w\d\-]+\]\sAS\s[[\w\d\-]+\]\s+),(\[[\w\d\-]+\]\sAS\s[[\w\d\-]+\]\s+,){3}(\[[\w\d\-]+\]\sAS\s[[\w\d\-]+\]\s+)FROM\s+\[[\w\d\-]+\]\.\[[\w\d\-]+");
            Assert.True(r.IsMatch(generateSql));
        }
    }
}