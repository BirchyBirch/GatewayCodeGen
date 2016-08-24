using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface IDataTransferObjectGenerator
    {
        string GenerateCode(CodeGenerationConfiguration config, DatabaseTableDefinition tableDefinition);
    }
}