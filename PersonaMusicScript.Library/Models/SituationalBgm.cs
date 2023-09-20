namespace PersonaMusicScript.Library.Models;

public class SituationalBgm : IMusic
{
    public SituationalBgm(IMusic normal, IMusic advantage, IMusic? disadvantage = null)
    {
        if (normal is SituationalBgm
            || advantage is SituationalBgm
            || disadvantage is SituationalBgm)
        {
            throw new ArgumentException("Situational BGM can not use Situational BGM.");
        }

        this.NormalBGM = normal;
        this.AdvantageBGM = advantage;
        this.DisadvantageBGM = disadvantage;
    }

    public IMusic NormalBGM { get; set; }

    public IMusic AdvantageBGM { get; set; }

    public IMusic? DisadvantageBGM { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is SituationalBgm other)
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
