namespace PersonaMusicScript.Library.Models;

public class BattleBgm : IMusic
{
    private readonly MusicSource source;

    public BattleBgm(
        MusicResources resources,
        MusicSource source,
        IMusic? normal,
        IMusic? advantage,
        IMusic? disadvantage)
    {
        if (normal is BattleBgm
            || advantage is BattleBgm
            || disadvantage is BattleBgm)
        {
            throw new ArgumentException("Battle BGM can not use Battle BGM.");
        }

        this.source = source;
        this.NormalBGM = normal ?? resources.Constants.DefaultNormalMusic;
        this.AdvantageBGM = advantage ?? resources.Constants.DefaultAdvantageMusic;
        this.DisadvantageBGM = disadvantage ?? resources.Constants.DefaultDisadvantageMusic;
        if (!source.BattleBgms.Contains(this))
        {
            source.BattleBgms.Add(this);
        }
    }

    public int Id => this.source.BattleBgms.IndexOf(this);

    public MusicType Type { get; } = MusicType.BattleBgm;

    public IMusic NormalBGM { get; set; }

    public IMusic AdvantageBGM { get; set; }

    public IMusic DisadvantageBGM { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is BattleBgm other)
        {
            if (this.NormalBGM.Equals(other.NormalBGM)
                && this.AdvantageBGM.Equals(other.AdvantageBGM)
                && this.DisadvantageBGM.Equals(other.DisadvantageBGM))
            {
                return true;
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
