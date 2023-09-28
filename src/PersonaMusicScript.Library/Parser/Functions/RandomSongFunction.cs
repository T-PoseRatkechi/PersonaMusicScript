using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class RandomSongFunction : IFunction<RandomSong>
{
    private readonly MusicSource source;
    private readonly ExpressionVisitor expressionVisitor;

    public RandomSongFunction(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "random_song";

    public RandomSong Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 2, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length != 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }

        var minExp = argExps[0];
        var maxExp = argExps[1];

        var minValue = this.expressionVisitor.Visit(minExp);
        var maxValue = this.expressionVisitor.Visit(maxExp);

        if (minValue is int min && maxValue is int max)
        {
            var randomSong = new RandomSong(this.source, min, max);
            return randomSong;
        }
        else
        {
            throw new ParsingException("Invalid function arguments.", context);
        }
    }
}
