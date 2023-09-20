using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser;

internal class ExpressionVisitor : SourceBaseVisitor<object>
{
    private readonly MusicSource source;
    private readonly FunctionVisitor functionVisitor;

    public ExpressionVisitor(MusicSource source)
    {
        this.source = source;
        this.functionVisitor = new(this);
    }

    public override object VisitStringExpression([NotNull] SourceParser.StringExpressionContext context)
    {
        return context.STRING().GetText();
    }

    public override object VisitIntExpression([NotNull] SourceParser.IntExpressionContext context)
    {
        var result = int.TryParse(context.INT().GetText(), out var value);
        return result ? value : throw new ParsingException("Failed to parse int.", context);
    }

    public override object VisitIdExpression([NotNull] SourceParser.IdExpressionContext context)
    {
        var id = context.ID().GetText();
        if (this.source.Constants.TryGetValue(id, out var value))
        {
            return value;
        }
        else
        {
            throw new ParsingException($"Constant \"{id}\" is undefined.", context);
        }
    }

    public override object VisitFunction([NotNull] SourceParser.FunctionContext context)
    {
        var value = functionVisitor.Visit(context);
        return value;
    }
}
