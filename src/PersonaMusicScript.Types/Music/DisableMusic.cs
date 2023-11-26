namespace PersonaMusicScript.Types.Music;

/// <summary>
/// Instruct to block the music from playing, if possible.
/// </summary>
public class DisableMusic : IMusic
{
    public MusicType Type { get; } = MusicType.DisableMusic;
}
