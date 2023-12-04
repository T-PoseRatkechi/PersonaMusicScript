namespace PersonaMusicScript.Types.Music;

/// <summary>
/// Set of battle and victory BGM.
/// </summary>
public class BattleVictorySet : IMusic
{
    public BattleVictorySet(IMusic battleMusic, IMusic victoryMusic)
    {
        if (battleMusic.Type == MusicType.BattleVictorySet
            || victoryMusic.Type == MusicType.BattleVictorySet)
        {
            throw new Exception($"{nameof(BattleVictorySet)} cannot use another {nameof(BattleVictorySet)}.");
        }

        this.BattleMusic = battleMusic;
        this.VictoryMusic = victoryMusic;
    }

    public MusicType Type { get; } = MusicType.BattleVictorySet;

    public IMusic BattleMusic { get; set; }

    public IMusic VictoryMusic { get; set; }
}
