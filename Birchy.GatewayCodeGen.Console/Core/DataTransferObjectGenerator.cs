using System.Linq;
using Birchy.GatewayCodeGen.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace Birchy.GatewayCodeGen.Console.Core
{
    public class DataTransferObjectGenerator
    {
        public string GenerateCode(CodeGenerationConfiguration config, DatabaseTableDefinition tableDefinition)
        {
            SyntaxNode compilationUnitSyntax = SyntaxFactory.CompilationUnit()
                .AddUsings(
                    CreateUsingDirectives())
                .AddMembers(
                    SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(config.CoreNamespace))
                        .AddMembers(
                            SyntaxFactory.ClassDeclaration(tableDefinition.DtoName)
                                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                                .AddMembers(BuildPropertyMembers(tableDefinition))
                        )
                );
            var adhocWorkspace = new AdhocWorkspace();
            var syntaxNode = Formatter.Format(compilationUnitSyntax, adhocWorkspace);            
            return syntaxNode.ToFullString();
        }

        private static MemberDeclarationSyntax[] BuildPropertyMembers(DatabaseTableDefinition tableDefinition)
        {            
            return tableDefinition.Columns.Select(CreatePropertyDeclarationSyntax).Cast<MemberDeclarationSyntax>().ToArray();
        }

        private static PropertyDeclarationSyntax CreatePropertyDeclarationSyntax(DatabaseColumnDefinition columnDefinition)
        {
            return SyntaxFactory.PropertyDeclaration(
                    SyntaxFactory.ParseTypeName(columnDefinition.FullCSharpType), columnDefinition.Name)
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)))
                .WithModifiers(SyntaxTokenList.Create(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));
        }

        private static UsingDirectiveSyntax CreateUsingDirectives()
        {
            return SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System"));
        }
    }
}