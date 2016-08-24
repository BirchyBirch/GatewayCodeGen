using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface ISqlGenerator
    {
        string GenerateSelect(DatabaseTableDefinition tableDefitition);
        string GenerateInsert(DatabaseTableDefinition tableDefitition);
    }
}