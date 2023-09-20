using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class CommandBlockVisitor : SourceBaseVisitor<CommandBlock>
{
    private readonly ExpressionVisitor expressionVisitor;
    private readonly CommandVisitor commandVisitor;

    public CommandBlockVisitor(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
        this.commandVisitor = new(expressionVisitor);
    }

    public override CommandBlock VisitCommandBlock([NotNull] SourceParser.CommandBlockContext context)
    {
        var typeString = context.ID().GetText();
        var type = Enum.Parse<CommandBlockType>(typeString, true);
        var arg = this.expressionVisitor.Visit(context.expression());
        var commands = new List<Command>();
        foreach (var commandCtx in context.command())
        {
            var command = this.commandVisitor.Visit(commandCtx);
            commands.Add(command);
        }

        return new(type, arg, commands.ToArray());
    }
}
