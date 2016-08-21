using Birchy.GatewayCodeGen.Core.Database;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Birchy.GatewayCodeGen.Engine
{
    public interface ISqlSyntaxGenerator
    {
        LiteralExpressionSyntax GetSelectQueryExpressionSyntax(DatabaseTableDefinition tableDefinitin);
    }
}