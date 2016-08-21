using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Engine;

namespace UnitTests.Engine
{
    public class GatewayBaseObjectGeneratorTestFixture
    {
        public GatewayBaseObjectGenerator Instance => new GatewayBaseObjectGenerator();

        public CodeGenerationConfiguration ConfigurationUsed => new CodeGenerationConfiguration
        {
            CoreNamespace = "Birchy.Core",
            DatabaseName = "BirchyDB",
            DataNamespace = "Bircy.Data",
            DalBaseClassName = "BirchyDBGateway"
        };

        public string ResultOfCreateGatewayBaseObject => Instance.GenerateGatewayBaseObject(
            ConfigurationUsed);
    }
}