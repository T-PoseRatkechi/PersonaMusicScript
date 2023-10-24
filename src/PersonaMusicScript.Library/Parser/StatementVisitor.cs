using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser;

internal class StatementVisitor : SourceBaseVisitor<bool>
{
    private readonly AssignmentVisitor assignmentVisitor;
    private readonly CommandBlockVisitor commandBlockVisitor;

    public StatementVisitor(AssignmentVisitor assignmentVisitor, CommandBlockVisitor commandBlockVisitor)
    {
        this.assignmentVisitor = assignmentVisitor;
        this.commandBlockVisitor = commandBlockVisitor;
    }

    public override bool VisitStatement([NotNull] SourceParser.StatementContext context)
    {
        if (context.assignment() is SourceParser.AssignmentContext assignment)
        {
            if (!this.assignmentVisitor.Visit(assignment))
            {
                throw new ParsingException("Failed to assign constant.", assignment);
            }
        }
        else if (context.commandBlock() is SourceParser.CommandBlockContext commandBlock)
        {
            if (!this.commandBlockVisitor.Visit(commandBlock))
            {
                throw new ParsingException("Failed to parse command block.", commandBlock);
            }
        }

        return true;
    }
}
