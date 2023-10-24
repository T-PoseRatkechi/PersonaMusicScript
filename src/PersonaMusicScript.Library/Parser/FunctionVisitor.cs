using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class FunctionVisitor : SourceBaseVisitor<object>
{
    private readonly FunctionTable functions;

    public FunctionVisitor(FunctionTable functions)
    {
        this.functions = functions;
    }

    public override object VisitFunction([NotNull] SourceParser.FunctionContext context)
    {
        var name = context.ID().GetText();
        if (this.functions.TryGetValue(name, out var func))
        {
            return func.Invoke(context) ?? throw new ParsingException("Failed to invoke function.", context);
        }

        throw new ParsingException($"Unknown function \"{name}\".", context);
    }
}
