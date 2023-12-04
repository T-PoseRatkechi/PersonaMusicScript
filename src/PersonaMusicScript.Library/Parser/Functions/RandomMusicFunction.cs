using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class RandomMusicFunction : IFunction<RandomMusic>
{
    private readonly ExpressionVisitor expressionVisitor;

    public RandomMusicFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "random_music";

    public RandomMusic Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 1, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length != 1)
        {
            throw new FunctionException(this.Name, 1, argExps.Length, context);
        }

        var array = this.expressionVisitor.Visit(argExps[0]) as IEnumerable<object>
            ?? throw new ArgumentException("Expected array of objects.");

        var musicList = array.Select(MusicUtils.GetMusic).ToArray();
        return new(musicList);
    }
}
