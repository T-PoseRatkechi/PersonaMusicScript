using LibellusLibrary.Event.Types.Frame;

namespace PersonaMusicScript.Library.Models;

public class FrameBgm : IMusic
{
    public PmdBgmType BgmType { get; set; }

    public IMusic? Music { get; set; }

    public MusicType Type { get; } = MusicType.FrameBgm;
}
