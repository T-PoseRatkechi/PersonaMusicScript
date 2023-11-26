using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class BattleBgmFunction : IFunction<BattleBgm>
{
    private readonly ExpressionVisitor expressionVisitor;

    public BattleBgmFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "battle_bgm";

    public BattleBgm Invoke([NotNull] SourceParser.FunctionContext context)
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
        else if (argExps.Length > 3)
        {
            throw new FunctionException(this.Name, 3, argExps.Length, context);
        }

        var normalExp = argExps[0];
        var advantageExp = argExps[1];
        var disadvantageExp = argExps.Length > 2 ? argExps[2] : null;

        var normalValue = this.expressionVisitor.Visit(normalExp);
        var advantageValue = this.expressionVisitor.Visit(advantageExp);
        var disadvantageValue = disadvantageExp != null ? this.expressionVisitor.Visit(disadvantageExp) : null;

        if (normalValue is int normalSongId)
        {
            normalValue = new Song(normalSongId);
        }

        if (advantageValue is int advantageSongId)
        {
            advantageValue = new Song(advantageSongId);
        }

        if (disadvantageValue is int disadvantageSongId)
        {
            disadvantageValue = new Song(disadvantageSongId);
        }

        if (normalValue is IMusic normalBgm
            && advantageValue is IMusic advantageBgm)
        {
            var disadvantageBgm = disadvantageValue as IMusic;

            // Validate disadvantage bgm if exists.
            if (argExps.Length > 2 && disadvantageBgm == null)
            {
                throw new ParsingException("Invalid function arguments.", context);
            }

            try
            {
                var battleBgm = new BattleBgm(normalBgm, advantageBgm, disadvantageBgm);
                return battleBgm;
            }
            catch (Exception ex)
            {
                throw new ParsingException("Failed to create Battle BGM.", context, ex);
            }
        }
        else
        {
            throw new ParsingException("Invalid function arguments.", context);
        }
    }
}
