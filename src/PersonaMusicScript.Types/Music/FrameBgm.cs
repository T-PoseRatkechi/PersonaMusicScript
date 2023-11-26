namespace PersonaMusicScript.Types.Music;

public class FrameBgm : IMusic
{
    public PmdBgmType BgmType { get; set; }

    public IMusic? Music { get; set; }

    public MusicType Type { get; } = MusicType.FrameBgm;
}

public enum PmdBgmType
    : ushort
{
    BGM_PLAY,
    BGM_FADE_IN,
    BGM_FADE_OUT,
    BGM_TRANSITION,
    BGM_VOLUME_DOWN,
    BGM_VOLUME_UP,
    BGM_ALL_STOP,
}