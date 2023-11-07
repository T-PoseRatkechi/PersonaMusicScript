using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class ExpressionVisitor : SourceBaseVisitor<object>
{
    private readonly ConstantTable constants;
    private readonly FunctionVisitor functionVisitor;

    public ExpressionVisitor(ConstantTable constants, FunctionVisitor functionVisitor)
    {
        this.constants = constants;
        this.functionVisitor = functionVisitor;
    }

    public override object VisitStringExpression([NotNull] SourceParser.StringExpressionContext context)
    {
        return context.STRING().GetText().Trim('"');
    }

    public override object VisitIntExpression([NotNull] SourceParser.IntExpressionContext context)
    {
        var result = int.TryParse(context.INT().GetText(), out var value);
        return result ? value : throw new ParsingException("Failed to parse int.", context);
    }

    public override object VisitIdExpression([NotNull] SourceParser.IdExpressionContext context)
    {
        var id = context.ID().GetText();
        if (this.constants.TryGetValue(id, out var value))
        {
            return value;
        }
        else
        {
            throw new ParsingException($"Constant \"{id}\" is undefined.", context);
        }
    }

    public override object VisitArray([NotNull] SourceParser.ArrayContext context)
    {
        var items = new List<object>();
        foreach (var exp in context.expression())
        {
            var item = this.Visit(exp);
            items.Add(item);
        }

        return items;
    }

    public override object VisitFunction([NotNull] SourceParser.FunctionContext context)
    {
        return functionVisitor.Visit(context);
    }
}
