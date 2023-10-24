using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class AssignmentVisitor : SourceBaseVisitor<bool>
{
    private readonly ConstantTable constants;
    private readonly ExpressionVisitor expressionVisitor;

    public AssignmentVisitor(ConstantTable constants, ExpressionVisitor expressionVisitor)
    {
        this.constants = constants;
        this.expressionVisitor = expressionVisitor;
    }

    public override bool VisitAssignment([NotNull] SourceParser.AssignmentContext context)
    {
        var id = context.ID().GetText();
        var value = this.expressionVisitor.Visit(context.expression());
        if (this.constants.ContainsKey(id))
        {
            throw new ParsingException($"Constant with name \"{id}\" already exists.", context);
        }

        if (!this.constants.TryAdd(id, value))
        {
            throw new ParsingException($"Failed to create constant \"{id}\".", context);
        }

        return true;
    }
}
