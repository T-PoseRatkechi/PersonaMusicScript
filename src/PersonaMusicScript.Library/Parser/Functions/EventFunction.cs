using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class EventFunction : IFunction<FrameTable>
{
    private readonly ExpressionVisitor expressionVisitor;

    public EventFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "event";

    public FrameTable Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 2, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length < 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }

        var majorId = this.expressionVisitor.Visit(argExps[0]) as int?;
        var minorId = this.expressionVisitor.Visit(argExps[1]) as int?;
        var pmdType = argExps.Length > 2 ? this.expressionVisitor.Visit(argExps[2]) as PmdType? : PmdType.PM3;

        if (majorId == null || minorId == null || pmdType == null)
        {
            throw new ParsingException("Invalid function argument(s).", context);
        }

        return new FrameTable((int)majorId, (int)minorId, (PmdType)pmdType);
    }
}
