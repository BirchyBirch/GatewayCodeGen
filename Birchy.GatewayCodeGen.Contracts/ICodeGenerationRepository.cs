using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface ICodeGenerationRepository
    {
        GeneratedDataAccessLayer GenerateDataAccessLayer(CodeGenerationConfiguration configuration);
        GeneratedCode[] GenerateCode(CodeGenerationConfiguration configuration);
    }
}