using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class CommandVisitor : SourceBaseVisitor<Command>
{
    private readonly ExpressionVisitor expressionVisitor;

    public CommandVisitor(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public override Command VisitCommand([NotNull] SourceParser.CommandContext context)
    {
        var name = context.ID().GetText();
        var value = this.expressionVisitor.Visit(context.expression());
        return new(name, value);
    }
}
