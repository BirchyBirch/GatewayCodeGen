using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Engine;
using Xunit;

namespace UnitTests.Engine
{
    public class SettingsObjectGeneratorTests
    {
        private static SettingsObjectGenerator GetSettingsObjectGenerator()
        {
            return new SettingsObjectGenerator();
        }

        [Fact]
        public void Constructor_CreatesNewInstance()
        {
            Assert.NotNull(GetSettingsObjectGenerator());
        }

        [Fact]
        public void CreateSettingsInterface_CreateCorrectSource()
        {
            var settingsObjectGenerator = GetSettingsObjectGenerator();
            var settingsInterface = settingsObjectGenerator.CreateSettingsInterface(new CodeGenerationConfiguration
            {
                CoreNamespace = "Birchy.Core",
                DatabaseName = "BirchyDB"
            });
            Assert.Contains("namespace Birchy.Core", settingsInterface);
            Assert.Contains("public interface IDatabaseSettings", settingsInterface);
            Assert.Contains("string BirchyDBConnectionString", settingsInterface);
            Assert.Contains("get;", settingsInterface);
            Assert.DoesNotContain("set;", settingsInterface);
        }
    }
}