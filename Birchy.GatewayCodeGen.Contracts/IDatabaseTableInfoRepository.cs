using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface IDatabaseTableInfoRepository
    {
        DatabaseTableDefinition[] GetDefinitions(CodeGenerationConfiguration configuration);
    }
}