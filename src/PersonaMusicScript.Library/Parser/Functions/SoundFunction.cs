using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class SoundFunction : IFunction<Sound>
{
    private readonly ExpressionVisitor expressionVisitor;

    public SoundFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "sound";

    public Sound Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 2, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length < 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }

        if (argExps.Length > 4)
        {
            throw new FunctionException(this.Name, 4, argExps.Length, context);
        }

        var musicValue = this.expressionVisitor.Visit(argExps[0]);
        var setting1Value = this.expressionVisitor.Visit(argExps[1]);
        object? setting2Value = (argExps.Length == 3) ? this.expressionVisitor.Visit(argExps[2]) : null;
        object? setting3Value = (argExps.Length == 4) ? this.expressionVisitor.Visit(argExps[3]) : null;

        if (musicValue is IMusic music
            && setting1Value is int setting1)
        {
            return new Sound(music)
            {
                Setting_1 = setting1,
                Setting_2 = setting2Value as int? ?? 0,
                Setting_3 = setting3Value as int? ?? 0,
            };
        }

        throw new ParsingException("Invalid function argument.", context);
    }
}
