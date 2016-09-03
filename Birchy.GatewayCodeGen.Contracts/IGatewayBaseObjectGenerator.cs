using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface IGatewayBaseObjectGenerator
    {
        string GenerateGatewayBaseObject(CodeGenerationConfiguration configuration);
    }
}