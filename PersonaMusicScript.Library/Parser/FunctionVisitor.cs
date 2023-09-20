using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Functions;

namespace PersonaMusicScript.Library.Parser;

internal class FunctionVisitor : SourceBaseVisitor<object>
{
    private readonly Dictionary<string, Func<SourceParser.FunctionContext, object?>> functions = new();

    public FunctionVisitor(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.AddFunction(new SongFunction(expressionVisitor));
        this.AddFunction(new RandomSongFunction(source, expressionVisitor));
        this.AddFunction(new SituationalBgmFunction(source, expressionVisitor));
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

    private void AddFunction<T>(IFunction<T> function)
    {
        this.functions.Add(function.Name, (context) => function.Invoke(context));
    }
}
