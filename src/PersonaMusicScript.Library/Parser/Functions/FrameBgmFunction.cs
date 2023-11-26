using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class FrameBgmFunction : IFunction<FrameBgm>
{
    private readonly ExpressionVisitor expressionVisitor;

    public FrameBgmFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "frame_bgm";

    public FrameBgm Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 2, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length < 1)
        {
            throw new FunctionException(this.Name, 1, argExps.Length, context);
        }

        if (argExps.Length > 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }

        var bgmType = this.expressionVisitor.Visit(argExps[0]) as PmdBgmType?;
        var musicValue = argExps.Length == 2 ? this.expressionVisitor.Visit(argExps[1]) : 0;
        var music = MusicUtils.GetMusic(musicValue);

        if (bgmType == null || music == null)
        {
            throw new ParsingException("Invalid function argument(s).", context);
        }

        return new FrameBgm { BgmType = (PmdBgmType)bgmType, Music = music };
    }
}
