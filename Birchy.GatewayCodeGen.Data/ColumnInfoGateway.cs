using System.Linq;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core.Database;

namespace Birchy.GatewayCodeGen.Data
{
    public class ColumnInfoGateway : GatewayBase, IColumnInfoGateway
    {
        public ColumnInfoGateway(string connectionString) : base(connectionString)
        {
        }

        public ColumnDto[] GetAll()
        {
            var sql = @"select	c.object_id ObjectId
		,c.Name
		,type_name(system_type_id) as SqlDataType
		,Is_nullable IsNullable
		,is_identity IsIdentity
from	sys.columns C	
		INNER JOIN sys.tables T
		on c.object_id = t.object_id";
            return GetFromDatabase<ColumnDto>(sql, null).ToArray();
        }
    }
}