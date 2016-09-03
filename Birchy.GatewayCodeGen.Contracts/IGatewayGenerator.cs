using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface IGatewayGenerator
    {
        string GenerateGatewayClass(CodeGenerationConfiguration configuration, DatabaseTableDefinition tableDefinition);
    }
}