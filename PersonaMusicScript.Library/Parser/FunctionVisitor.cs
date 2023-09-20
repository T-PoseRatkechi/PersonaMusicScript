using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class FunctionVisitor : SourceBaseVisitor<Function>
{
    private readonly ExpressionVisitor expressionVisitor;

    public FunctionVisitor(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public override Function VisitFunction([NotNull] SourceParser.FunctionContext context)
    {
        var name = context.ID().GetText();
        var args = new List<object>();
        foreach (var argExp in context.exprList().expression())
        {
            var argValue = this.expressionVisitor.Visit(argExp);
            args.Add(argValue);
        }

        return new(name, args.ToArray());
    }
}
