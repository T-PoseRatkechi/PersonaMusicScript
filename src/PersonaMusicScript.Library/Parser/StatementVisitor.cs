using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser;

internal class StatementVisitor : SourceBaseVisitor<bool>
{
    private readonly MusicSource source;
    private readonly AssignmentVisitor assignmentVisitor;
    private readonly CommandBlockVisitor commandBlockVisitor;

    public StatementVisitor(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.assignmentVisitor = new(source, expressionVisitor);
        this.commandBlockVisitor = new(expressionVisitor);
    }

    public override bool VisitStatement([NotNull] SourceParser.StatementContext context)
    {
        if (context.assignment() != null)
        {
            if (!this.assignmentVisitor.Visit(context.assignment()))
            {
                throw new ParsingException("Failed to assign constant.", context.assignment());
            }
        }

        if (context.commandBlock() != null)
        {
            var block = this.commandBlockVisitor.Visit(context)
                ?? throw new ParsingException("Failed to parse command block.", context.commandBlock());
            this.source.Blocks.Add(block);
        }

        return true;
    }
}
