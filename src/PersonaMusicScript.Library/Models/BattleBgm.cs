namespace PersonaMusicScript.Library.Models;

public class BattleBgm : IMusic
{
    public BattleBgm(
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

        this.NormalMusic = normal;
        this.AdvantageMusic = advantage;
        this.DisadvantageMusic = disadvantage;
    }

    public MusicType Type { get; } = MusicType.BattleBgm;

    public IMusic? NormalMusic { get; set; }

    public IMusic? AdvantageMusic { get; set; }

    public IMusic? DisadvantageMusic { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is BattleBgm other)
        {
            // Compare normal music.
            if (this.NormalMusic is not null
                && other.NormalMusic is not null)
            {
                if (!this.NormalMusic.Equals(other.NormalMusic))
                {
                    return false;
                }
            }

            if (this.NormalMusic != other.NormalMusic)
            {
                return false;
            }

            // Compare advantage music.
            if (this.AdvantageMusic is not null
                && other.AdvantageMusic is not null)
            {
                if (!this.AdvantageMusic.Equals(other.AdvantageMusic))
                {
                    return false;
                }
            }

            if (this.AdvantageMusic != other.AdvantageMusic)
            {
                return false;
            }

            // Compare disadvantage music.
            if (this.DisadvantageMusic is not null
                && other.DisadvantageMusic is not null)
            {
                if (!this.DisadvantageMusic.Equals(other.DisadvantageMusic))
                {
                    return false;
                }
            }

            if (this.DisadvantageMusic != other.DisadvantageMusic)
            {
                return false;
            }

            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
