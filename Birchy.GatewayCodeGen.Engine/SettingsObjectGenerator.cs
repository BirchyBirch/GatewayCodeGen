using Birchy.GatewayCodeGen.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace Birchy.GatewayCodeGen.Engine
{
    public class SettingsObjectGenerator
    {
        private static readonly AdhocWorkspace WorkSpace = new AdhocWorkspace();

        public string CreateSettingsInterface(CodeGenerationConfiguration configuration)
        {
            SyntaxNode compilationUnitSyntax = SyntaxFactory.CompilationUnit()
                .AddMembers(
                    SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(configuration.CoreNamespace))
                        .AddMembers(
                            SyntaxFactory.InterfaceDeclaration("IDatabaseSettings")
                                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                                .AddMembers(
                                    SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("string"),
                                            configuration.ConnectionStringName)
                                        .AddAccessorListAccessors(
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)))
                                )
                        ));
            var syntaxNode = Formatter.Format(compilationUnitSyntax, WorkSpace);
            return syntaxNode.ToFullString();
        }
    }
}