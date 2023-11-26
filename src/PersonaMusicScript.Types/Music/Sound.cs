namespace PersonaMusicScript.Types.Music;

public class Sound : IMusic
{
    public Sound(IMusic music)
    {
        this.Music = music;
    }

    public IMusic Music { get; }

    public int Setting_1 { get; set; }

    public int Setting_2 { get; set; }

    public int Setting_3 { get; set; }

    public MusicType Type { get; } = MusicType.Sound;
}
