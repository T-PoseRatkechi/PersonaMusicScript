using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Types.MusicCollections.Entries;

public class GlobalBgmEntry : BaseEntry
{
    public GlobalBgmEntry(int bgmId, IMusic music)
        : base(bgmId)
    {
        this.Name = $"Global BGM: {bgmId}";
        this.Music = music;
    }

    public GlobalBgmEntry(string songName, IMusic music)
        : base(songName)
    {
        this.Name = songName;
        this.Music = music;
    }

    public IMusic Music { get; set; }
}
