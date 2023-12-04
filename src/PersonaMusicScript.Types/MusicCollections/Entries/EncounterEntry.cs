using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Types.MusicCollections.Entries;

public class EncounterEntry : BaseEntry
{
    private IMusic? battleMusic;
    private IMusic? victoryMusic;

    private IMusic? victoryFromSet;

    public EncounterEntry(int encounterId)
        : base(encounterId)
    {
        Name = $"Encounter: {encounterId}";
    }

    public EncounterEntry(string collectionName)
        : base(collectionName)
    {
        Name = collectionName;
    }

    public IMusic? BattleMusic
    {
        get
        {
            var currentMusic = this.battleMusic;

            // Pre select a random music to handle
            // random battle victory sets.
            if (currentMusic is RandomMusic randomMusic)
            {
                currentMusic = randomMusic.GetRandomMusic();
            }

            // Set battle+victory music to music from set.
            if (currentMusic is BattleVictorySet battleVictorySet)
            {
                this.victoryFromSet = battleVictorySet.VictoryMusic;
                return battleVictorySet.BattleMusic;
            }
            
            // Clear any victory music from a previous set.
            else
            {
                this.victoryFromSet = null;
            }

            return currentMusic;
        }

        set => this.battleMusic = value;
    }

    public IMusic? VictoryMusic
    {
        get
        {
            if (this.victoryFromSet != null)
            {
                return this.victoryFromSet;
            }

            return this.victoryMusic;
        }

        set => this.victoryMusic = value;
    }
}
