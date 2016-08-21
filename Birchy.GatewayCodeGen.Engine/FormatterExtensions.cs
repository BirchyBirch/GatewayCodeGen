using Birchy.GatewayCodeGen.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace Birchy.GatewayCodeGen.Engine
{
    public static class FormatterExtensions
    {
        public static string ToFormattedSource(this SyntaxNode node, AdhocWorkspace workspace)
        {
            var syntaxNode = Formatter.Format(node, workspace);
            return syntaxNode.ToFullString();
        }

        public static NamespaceDeclarationSyntax DataNamespaceSyntax(this CodeGenerationConfiguration config)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(config.DataNamespace));
        }

        public static NamespaceDeclarationSyntax CoreNamespaceSyntax(this CodeGenerationConfiguration config)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(config.CoreNamespace));
        }

        public static NamespaceDeclarationSyntax ContractNamespaceSyntax(this CodeGenerationConfiguration config)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(config.ContractNamespace));
        }
    }
}