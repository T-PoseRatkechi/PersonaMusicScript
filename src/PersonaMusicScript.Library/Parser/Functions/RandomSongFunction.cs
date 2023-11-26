using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class RandomSongFunction : IFunction<RandomSong>
{
    private readonly ExpressionVisitor expressionVisitor;

    public RandomSongFunction(ExpressionVisitor expressionVisitor)
    {
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

        // Array of BGM IDs.
        if (argExps.Length == 1)
        {
            var bgmArray = this.expressionVisitor.Visit(argExps[0]);
            if (bgmArray is not IEnumerable<object> array)
            {
                throw new ParsingException("Expected array argument.", context);
            }

            var ids = array.Select(x =>
            {
                if (x is Song song)
                {
                    return song.Id;
                }
                else if (x is int id)
                {
                    return id;
                }

                throw new ParsingException("Invalid array item for random song.", context);
            }).ToArray();

            if (ids.Length < 1)
            {
                throw new ParsingException("At least one BGM ID is required.", context);
            }

            return new(ids);
        }

        if (argExps.Length > 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }

        var minExp = argExps[0];
        var maxExp = argExps[1];

        var minValue = this.expressionVisitor.Visit(minExp);
        var maxValue = this.expressionVisitor.Visit(maxExp);

        if (minValue is int min && maxValue is int max)
        {
            var randomSong = new RandomSong(min, max);
            return randomSong;
        }
        else
        {
            throw new ParsingException("Invalid function arguments.", context);
        }
    }
}
