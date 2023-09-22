namespace PersonaMusicScript.Library.Models;

public class BattleBgm : IMusic
{
    private readonly MusicSource source;

    public BattleBgm(
        MusicSource source,
        IMusic normal,
        IMusic advantage,
        IMusic? disadvantage = null)
    {
        if (normal is BattleBgm
            || advantage is BattleBgm
            || disadvantage is BattleBgm)
        {
            throw new ArgumentException("Battle BGM can not use Battle BGM.");
        }

        this.source = source;
        this.NormalBGM = normal;
        this.AdvantageBGM = advantage;
        this.DisadvantageBGM = disadvantage;
        if (!source.BattleBgms.Contains(this))
        {
            source.BattleBgms.Add(this);
        }
    }

    public int Id => this.source.BattleBgms.IndexOf(this);

    public MusicType Type { get; } = MusicType.BattleBgm;

    public IMusic? NormalBGM { get; set; }

    public IMusic? AdvantageBGM { get; set; }

    public IMusic? DisadvantageBGM { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is BattleBgm other)
        {
            if (this.NormalBGM.Equals(other.NormalBGM)
                && this.AdvantageBGM.Equals(other.AdvantageBGM))
            {
                if (this.DisadvantageBGM == null && other.DisadvantageBGM == null)
                {
                    return true;
                }

                if (this.DisadvantageBGM != null
                    && other.DisadvantageBGM != null
                    && this.DisadvantageBGM.Equals(other.DisadvantageBGM))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
