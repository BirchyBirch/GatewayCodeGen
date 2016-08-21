using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Data
{
    public class TableInfoGateway : GatewayBase, ITableInfoGateway
    {
        public TableInfoGateway(IDatabaseSettings settings) : base(settings)
        {
        }

        public TableInfoDto[] GetAll()
        {
            const string sql = @"select	Name
		                                ,Object_id ObjectId
		                                ,Schema_Name(Schema_id) SchemaName
                                from	sys.tables";
            return GetFromDatabase<TableInfoDto>(sql, null);
        }
    }
}