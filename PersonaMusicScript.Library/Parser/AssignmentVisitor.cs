using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser;

internal class AssignmentVisitor : SourceBaseVisitor<bool>
{
    private readonly MusicSource source;
    private readonly ExpressionVisitor expressionVisitor;

    public AssignmentVisitor(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.expressionVisitor = expressionVisitor;
    }

    public override bool VisitAssignment([NotNull] SourceParser.AssignmentContext context)
    {
        var id = context.ID().GetText();
        var value = this.expressionVisitor.Visit(context.expression());
        if (!this.source.Constants.TryAdd(id, value))
        {
            throw new ParsingException($"Failed to create constant \"{id}\" with value \"{value}\".", context);
        }

        return true;
    }
}
