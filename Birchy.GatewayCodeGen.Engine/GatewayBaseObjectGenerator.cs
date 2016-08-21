using Birchy.GatewayCodeGen.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Birchy.GatewayCodeGen.Engine
{
    public class GatewayBaseObjectGenerator
    {
        private const string SettingsInterfaceName = "IDatabaseSettings";
        private const string SettingsFieldName = "DatabaseSettings";
        private const string SettingsParamName = "databaseSettings";
        private const string ProviderConnectionType = "SqlConnection";
        private const string FactoryMethodName = "ConnectionFactory";
        private const string GenericTypeIdentifier = "T";
        private static readonly TypeSyntax GenericTypeArraySyntax = SyntaxFactory.ParseTypeName($"{GenericTypeIdentifier}[]");
        private static readonly AdhocWorkspace Workspace = new AdhocWorkspace();

        public string GenerateGatewayBaseObject(CodeGenerationConfiguration configuration)
        {            
            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddUsings(GenerateUsings())
                .AddMembers(configuration.DataNamespaceSyntax()
                    .AddMembers(SyntaxFactory.ClassDeclaration(configuration.DalBaseClassName)
                            .AddModifiers(GetClassModifiers())
                            .AddMembers(
                                GenerateSettingsField(),
                                GenerateConstructor(configuration),
                                GenerateFactoryMethod(configuration),
                                GenerateGetManyMethod()
                            )
                    ));            
            return compilationUnit.ToFormattedSource(Workspace);
        }

        private static MethodDeclarationSyntax GenerateGetManyMethod()
        {
            return SyntaxFactory.MethodDeclaration(GenericTypeArraySyntax,"GetManyFromDatabase")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword))
                .AddTypeParameterListParameters(SyntaxFactory.TypeParameter(GenericTypeIdentifier))
                .AddParameterListParameters(
                    SyntaxFactory.Parameter(new SyntaxList<AttributeListSyntax>(), new SyntaxTokenList(), SyntaxFactory.ParseTypeName("string"), SyntaxFactory.Identifier("sql"),null),
                    SyntaxFactory.Parameter(new SyntaxList<AttributeListSyntax>(), new SyntaxTokenList(), SyntaxFactory.ParseTypeName("object"), SyntaxFactory.Identifier("param"), null)
                );
        }

        private static MethodDeclarationSyntax GenerateFactoryMethod(CodeGenerationConfiguration configuration)
        {
            return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(ProviderConnectionType),FactoryMethodName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
                .AddBodyStatements(
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(ProviderConnectionType))
                            .WithArgumentList(SyntaxFactory.ArgumentList()
                                .AddArguments(
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            SyntaxFactory.ParseExpression(SettingsFieldName),
                                            SyntaxFactory.Token(SyntaxKind.DotToken),
                                            SyntaxFactory.IdentifierName(configuration.ConnectionStringName)))))));
        }

        private static FieldDeclarationSyntax GenerateSettingsField()
        {
            return SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(SettingsInterfaceName))
                        .AddVariables(SyntaxFactory.VariableDeclarator(SettingsFieldName)))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        private static ConstructorDeclarationSyntax GenerateConstructor(CodeGenerationConfiguration configuration)
        {
            return SyntaxFactory.ConstructorDeclaration(configuration.DalBaseClassName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword))
                .AddParameterListParameters(
                    SyntaxFactory.Parameter(new SyntaxList<AttributeListSyntax>(), new SyntaxTokenList(),
                        SyntaxFactory.ParseTypeName(SettingsInterfaceName),
                        SyntaxFactory.Identifier(SettingsParamName), null)
                )
                .AddBodyStatements(
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.IdentifierName(SettingsFieldName),
                            SyntaxFactory.Token(SyntaxKind.EqualsToken),
                            SyntaxFactory.IdentifierName(SettingsParamName))
                    )
                );
        }

        public SyntaxToken[] GetClassModifiers()
        {
            return new[]
            {
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.AbstractKeyword)
            };
        }

        private UsingDirectiveSyntax[] GenerateUsings()
        {
            return new[]
            {
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Dapper")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Data.SqlClient")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Data")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq"))
            };
        }
    }
}