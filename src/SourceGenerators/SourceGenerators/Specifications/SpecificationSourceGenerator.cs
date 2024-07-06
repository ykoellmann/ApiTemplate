using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceGenerators.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SourceGenerators.Specifications;

[Generator]
public class SpecificationSourceGenerator : ISourceGenerator
{
    private const string _methodSuffix = "Gen";

    private readonly List<string> _methods = new()
    {
        SpecificationConstants.Methods.Order,
        SpecificationConstants.Methods.Include,
        SpecificationConstants.Methods.Map
    };

    private readonly List<string> _properties = new()
    {
        SpecificationConstants.Properties.AsNoTracking,
        SpecificationConstants.Properties.AsSplitQuery,
        SpecificationConstants.Properties.IgnoreQueryFilters
    };

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new SpecificationSyntaxReceiver());
    }

    //TODO add diagnostics
    // public void Execute(GeneratorExecutionContext context)
    // {
    //     var receiver = (SpecificationSyntaxReceiver)context.SyntaxReceiver!;
    //     var specifications = receiver.Specifications;
    //
    //     if (specifications.Count == 0)
    //         return;
    //
    //     foreach (var specification in receiver.Specifications)
    //     {
    //         var methods = specification.Members
    //             .OfType<MethodDeclarationSyntax>()
    //             .Where(method => method
    //                 .Modifiers
    //                 .Any(node => node
    //                     .IsKind(SyntaxKind.OverrideKeyword)))
    //             .Where(method => _methods.Contains(method.Identifier.ToString()))
    //             .ToList();
    //
    //         if (!methods.Any())
    //             continue;
    //
    //         var members = new SyntaxList<MemberDeclarationSyntax>();
    //         foreach (var method in methods)
    //         {
    //             MethodDeclarationSyntax genMethod;
    //             if (method.Identifier.ToString() == SpecificationConstants.Methods.Map)
    //             {
    //                 genMethod = method
    //                     .WithModifiers(
    //                         method.Modifiers.Remove(method.Modifiers.First(node =>
    //                             node.IsKind(SyntaxKind.OverrideKeyword))))
    //                     .WithIdentifier(Identifier(method.Identifier + _methodSuffix));
    //             }
    //             else
    //             {
    //                 var queryableType = GenericName(Identifier("IQueryable"))
    //                     .WithTypeArgumentList(
    //                         TypeArgumentList(
    //                             SingletonSeparatedList<TypeSyntax>(
    //                                 ((GenericNameSyntax)method.ReturnType)
    //                                 .TypeArgumentList.Arguments.First())));
    //
    //                 // Set the return type of the method
    //                 genMethod = method
    //                     .WithModifiers(
    //                         method.Modifiers.Remove(method.Modifiers.First(node =>
    //                             node.IsKind(SyntaxKind.OverrideKeyword))))
    //                     .WithReturnType(queryableType)
    //                     .WithIdentifier(Identifier(method.Identifier + _methodSuffix))
    //                     .WithParameterList(
    //                         ParameterList(
    //                             SingletonSeparatedList<ParameterSyntax>(
    //                                 Parameter(method.ParameterList.Parameters.Single().Identifier)
    //                                     .WithType(queryableType))));
    //             }
    //
    //
    //             var methodBody = genMethod.Body?.Statements
    //                 .Select(statement => statement.ToString())
    //                 .ToList();
    //
    //             MethodDeclarationSyntax methodDeclaration;
    //             if (methodBody is not null)
    //             {
    //                 methodDeclaration = genMethod
    //                     .WithBody(Block(methodBody.Select(body => ParseStatement(body))));
    //             }
    //             else
    //             {
    //                 methodDeclaration = genMethod
    //                     .WithExpressionBody(genMethod.ExpressionBody!);
    //             }
    //
    //             members = members.Add(methodDeclaration);
    //         }
    //
    //
    //         var file =
    //             SingletonList<MemberDeclarationSyntax>(
    //                 specification.GetParent<FileScopedNamespaceDeclarationSyntax>().Single()
    //                     .WithMembers(
    //                         SingletonList<MemberDeclarationSyntax>(
    //                             ClassDeclaration(specification.Identifier.ToString())
    //                                 .WithModifiers(
    //                                     TokenList(
    //                                         [Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword)]))
    //                                 .WithMembers(members))));
    //
    //         var usings = new SyntaxList<UsingDirectiveSyntax>(
    //             new List<UsingDirectiveSyntax>
    //             {
    //                 UsingDirective(ParseName("Microsoft.EntityFrameworkCore")),
    //                 UsingDirective(ParseName("Microsoft.EntityFrameworkCore.Query")),
    //             });
    //         usings = usings.AddRange(specification.GetParent<CompilationUnitSyntax>().Single()
    //             .GetChildren<UsingDirectiveSyntax>());
    //
    //         //create compilation unit
    //         var compilationUnit = CompilationUnit()
    //             .WithUsings(usings)
    //             .WithMembers(file);
    //
    //         var source = "// <auto-generated/>\r\n";
    //         source += compilationUnit
    //             .NormalizeWhitespace()
    //             .ToFullString();
    //
    //         context.AddSource($"{specification.Identifier}.g.cs", source);
    //     }
    // }

    public void Execute(GeneratorExecutionContext context)
    {
        var receiver = (SpecificationSyntaxReceiver)context.SyntaxReceiver!;
        var specifications = receiver.Specifications;

        if (specifications.Count == 0)
            return;

        foreach (var specification in receiver.Specifications)
        {
            var methods = specification.Members
                .OfType<MethodDeclarationSyntax>()
                .Where(method => method
                    .Modifiers
                    .Any(node => node
                        .IsKind(SyntaxKind.OverrideKeyword)))
                .Where(method => _methods.Contains(method.Identifier.ToString()))
                .ToList();

            var properties = specification.Members
                .OfType<PropertyDeclarationSyntax>()
                .Where(property => _properties.Contains(property.Identifier.ToString()))
                .ToList();

            if (!methods.Any() && !properties.Any())
                continue;

            var entityIdentifier = specification.BaseList
                .GetChildren<GenericNameSyntax>()
                .Single(type => type.Identifier.ToString() == "Specification")
                .TypeArgumentList.Arguments.First().ToString();

            var members = Block();

            foreach (var property in properties)
            {
                var statements = property.Identifier.ToString() switch
                {
                    SpecificationConstants.Properties.AsNoTracking => BuildAsNoTrackingStatement(),
                    SpecificationConstants.Properties.AsSplitQuery => BuildAsSplitQueryStatement(),
                    SpecificationConstants.Properties.IgnoreQueryFilters => BuildIgnoreQueryFiltersStatement(),
                    _ => throw new NotImplementedException()
                };
                members = members.AddStatements(statements.ToArray());
            }

            var mapReturn = false;
            foreach (var method in methods)
            {
                var statements = method.Identifier.ToString() switch
                {
                    SpecificationConstants.Methods.Include => BuildIncludeStatement(entityIdentifier, method),
                    SpecificationConstants.Methods.Order => BuildOrderStatement(entityIdentifier, method),
                    SpecificationConstants.Methods.Map => BuildMapStatement(method),
                    _ => throw new NotImplementedException()
                };

                if (method.Identifier.ToString() == SpecificationConstants.Methods.Map) mapReturn = true;

                members = members.AddStatements(statements.ToArray());
            }

            var returnIdentifier = entityIdentifier;
            if (!mapReturn)
                members = members.AddStatements(
                    ReturnStatement(
                        IdentifierName("query")));
            else
                returnIdentifier = specification.BaseList
                    .GetChildren<GenericNameSyntax>()
                    .Single(type => type.Identifier.ToString() == "Specification")
                    .TypeArgumentList.Arguments.Last().ToString();

            var file =
                SingletonList<MemberDeclarationSyntax>(
                    specification.GetParent<FileScopedNamespaceDeclarationSyntax>().Single()
                        .WithMembers(
                            SingletonList<MemberDeclarationSyntax>(
                                ClassDeclaration(specification.Identifier.ToString())
                                    .WithModifiers(
                                        TokenList(
                                            [Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword)]))
                                    .WithMembers(SingletonList<MemberDeclarationSyntax>(
                                        MethodDeclaration(
                                                GenericName(
                                                        Identifier("IQueryable"))
                                                    .WithTypeArgumentList(
                                                        TypeArgumentList(
                                                            SingletonSeparatedList<TypeSyntax>(
                                                                IdentifierName(returnIdentifier)))),
                                                Identifier("Specificate"))
                                            .WithModifiers(
                                                TokenList(
                                                [
                                                    Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword)
                                                ]))
                                            .WithParameterList(
                                                ParameterList(
                                                    SingletonSeparatedList(
                                                        Parameter(
                                                                Identifier("query"))
                                                            .WithType(
                                                                GenericName(
                                                                        Identifier("IQueryable"))
                                                                    .WithTypeArgumentList(
                                                                        TypeArgumentList(
                                                                            SingletonSeparatedList<TypeSyntax>(
                                                                                IdentifierName(entityIdentifier))))))))
                                            .WithBody(members))))));

            var usings = new SyntaxList<UsingDirectiveSyntax>(
                new List<UsingDirectiveSyntax>
                {
                    UsingDirective(ParseName("Microsoft.EntityFrameworkCore")),
                    UsingDirective(ParseName("Microsoft.EntityFrameworkCore.Query"))
                });
            usings = usings.AddRange(specification.GetParent<CompilationUnitSyntax>().Single()
                .GetChildren<UsingDirectiveSyntax>());

            //create compilation unit
            var compilationUnit = CompilationUnit()
                .WithUsings(usings)
                .WithMembers(file);

            var source = "// <auto-generated/>\r\n";
            source += compilationUnit
                .NormalizeWhitespace()
                .ToFullString();

            context.AddSource($"{specification.Identifier}.g.cs", source);
        }
    }

    private List<StatementSyntax> BuildAsNoTrackingStatement()
    {
        return
        [
            IfStatement(
                IdentifierName(SpecificationConstants.Properties.AsNoTracking),
                Block(
                    SingletonList<StatementSyntax>(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("query"),
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName("query"),
                                        IdentifierName(SpecificationConstants.Properties.AsNoTracking))))))))
        ];
    }

    private List<StatementSyntax> BuildAsSplitQueryStatement()
    {
        return
        [
            IfStatement(
                IdentifierName(SpecificationConstants.Properties.AsSplitQuery),
                Block(
                    SingletonList<StatementSyntax>(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("query"),
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName("query"),
                                        IdentifierName(SpecificationConstants.Properties.AsSplitQuery))))))))
        ];
    }

    private List<StatementSyntax> BuildIgnoreQueryFiltersStatement()
    {
        return
        [
            IfStatement(
                IdentifierName(SpecificationConstants.Properties.IgnoreQueryFilters),
                Block(
                    SingletonList<StatementSyntax>(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("query"),
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        IdentifierName("query"),
                                        IdentifierName(SpecificationConstants.Properties.IgnoreQueryFilters))))))))
        ];
    }

    private List<StatementSyntax> BuildIncludeStatement(string entityName, MethodDeclarationSyntax method)
    {
        var queryableType = GenericName(Identifier("IQueryable"))
            .WithTypeArgumentList(
                TypeArgumentList(
                    SingletonSeparatedList(
                        ((GenericNameSyntax)method.ReturnType)
                        .TypeArgumentList.Arguments.First())));

        var func = LocalFunctionStatement(
                queryableType
                    .WithTypeArgumentList(
                        TypeArgumentList(
                            SingletonSeparatedList<TypeSyntax>(
                                IdentifierName(entityName)))),
                Identifier(SpecificationConstants.Methods.Include + _methodSuffix))
            .WithParameterList(
                ParameterList(
                    SingletonSeparatedList(
                        Parameter(
                                Identifier("includable"))
                            .WithType(
                                queryableType
                                    .WithTypeArgumentList(
                                        TypeArgumentList(
                                            SingletonSeparatedList<TypeSyntax>(
                                                IdentifierName(entityName))))))));

        var methodBody = method.Body?.Statements
            .Select(statement => statement.ToString())
            .ToList();

        if (methodBody is not null)
            func = func.WithBody(Block(methodBody.Select(body => ParseStatement(body))));
        else
            func = func.WithExpressionBody(method.ExpressionBody!);

        return
        [
            func,
            IfStatement(
                IsPatternExpression(
                    InvocationExpression(
                            IdentifierName(SpecificationConstants.Methods.Include + _methodSuffix))
                        .WithArgumentList(
                            ArgumentList(
                                SingletonSeparatedList(
                                    Argument(
                                        IdentifierName("query"))))),
                    RecursivePattern()
                        .WithPropertyPatternClause(
                            PropertyPatternClause())
                        .WithDesignation(
                            SingleVariableDesignation(
                                Identifier("includable")))),
                Block(
                    SingletonList<StatementSyntax>(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("query"),
                                IdentifierName("includable"))))))
        ];
    }

    private List<StatementSyntax> BuildOrderStatement(string entityName, MethodDeclarationSyntax method)
    {
        var queryableType = GenericName(Identifier("IQueryable"))
            .WithTypeArgumentList(
                TypeArgumentList(
                    SingletonSeparatedList(
                        ((GenericNameSyntax)method.ReturnType)
                        .TypeArgumentList.Arguments.First())));

        var func = LocalFunctionStatement(
                queryableType
                    .WithTypeArgumentList(
                        TypeArgumentList(
                            SingletonSeparatedList<TypeSyntax>(
                                IdentifierName(entityName)))),
                Identifier(SpecificationConstants.Methods.Order + _methodSuffix))
            .WithParameterList(
                ParameterList(
                    SingletonSeparatedList(
                        Parameter(
                                Identifier("ordered"))
                            .WithType(
                                queryableType
                                    .WithTypeArgumentList(
                                        TypeArgumentList(
                                            SingletonSeparatedList<TypeSyntax>(
                                                IdentifierName(entityName))))))));

        var methodBody = method.Body?.Statements
            .Select(statement => statement.ToString())
            .ToList();

        if (methodBody is not null)
            func = func.WithBody(Block(methodBody.Select(body => ParseStatement(body))));
        else
            func = func.WithExpressionBody(method.ExpressionBody!);

        return
        [
            func,
            IfStatement(
                IsPatternExpression(
                    InvocationExpression(
                            IdentifierName(SpecificationConstants.Methods.Order + _methodSuffix))
                        .WithArgumentList(
                            ArgumentList(
                                SingletonSeparatedList(
                                    Argument(
                                        IdentifierName("query"))))),
                    RecursivePattern()
                        .WithPropertyPatternClause(
                            PropertyPatternClause())
                        .WithDesignation(
                            SingleVariableDesignation(
                                Identifier("ordered")))),
                Block(
                    SingletonList<StatementSyntax>(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("query"),
                                IdentifierName("ordered"))))))
        ];
    }

    private List<StatementSyntax> BuildMapStatement(MethodDeclarationSyntax method)
    {
        var returnTypeName = (GenericNameSyntax)method.ReturnType;

        var func = LocalFunctionStatement(
            returnTypeName,
            Identifier(SpecificationConstants.Methods.Map + _methodSuffix));

        var methodBody = method.Body?.Statements
            .Select(statement => statement.ToString())
            .ToList();

        if (methodBody is not null)
            func = func.WithBody(Block(methodBody.Select(body => ParseStatement(body))));
        else
            func = func.WithExpressionBody(method.ExpressionBody!);

        return
        [
            func,
            ReturnStatement(
                InvocationExpression(
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName("query"),
                            IdentifierName("Select")))
                    .WithArgumentList(
                        ArgumentList(
                            SingletonSeparatedList(
                                Argument(
                                    InvocationExpression(
                                        IdentifierName(SpecificationConstants.Methods.Map + _methodSuffix)))))))
        ];
    }
}

public class SpecificationSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> Specifications { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not ClassDeclarationSyntax classDeclarationSyntax)
            return;

        var identifierTokens = classDeclarationSyntax.GetChildren<GenericNameSyntax>();
        if (identifierTokens.Any(node => node.Identifier.ToString() == "Specification"))
            Specifications.Add(classDeclarationSyntax);
    }
}