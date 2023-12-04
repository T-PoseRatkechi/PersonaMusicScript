using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class BattleVictorySetFunction : IFunction<BattleVictorySet>
{
    private readonly ExpressionVisitor expressionVisitor;

    public BattleVictorySetFunction(ExpressionVisitor expressionVisitor)
    {
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "battle_victory_set";

    public BattleVictorySet Invoke([NotNull] SourceParser.FunctionContext context)
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

        var battleMusicValue = this.expressionVisitor.Visit(argExps[0]);
        var victoryMusicValue = this.expressionVisitor.Visit(argExps[1]);

        var battleMusic = MusicUtils.GetMusic(battleMusicValue);
        var victoryMusic = MusicUtils.GetMusic(victoryMusicValue);
        return new(battleMusic, victoryMusic);
    }
}
