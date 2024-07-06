using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace SourceGenerators.Extensions;

public static class SyntaxNodeExtensions
{
    public static List<T> GetChildren<T>(this SyntaxNode node) where T : SyntaxNode
    {
        var children = new List<T>();
        foreach (var child in node.ChildNodes())
        {
            if (child is T t) children.Add(t);

            children.AddRange(GetChildren<T>(child));
        }

        return children;
    }

    public static List<T> GetParent<T>(this SyntaxNode node) where T : SyntaxNode
    {
        var parents = new List<T>();
        var parent = node.Parent;
        while (parent != null)
        {
            if (parent is T t) parents.Add(t);

            parent = parent.Parent;
        }

        return parents;
    }
}