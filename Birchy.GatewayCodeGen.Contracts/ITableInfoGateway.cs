using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface ITableInfoGateway
    {
        TableInfoDto[] GetAll();
    }
}