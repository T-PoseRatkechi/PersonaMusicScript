using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Types.MusicCollections;

public class GlobalMusic : Dictionary<int, IMusic>, IMusicEntries
{
    private readonly MusicResources resources;
    private readonly List<BaseEntry> entries = new();

    public GlobalMusic(MusicResources resources)
    {
        this.resources = resources;
    }

    public IEnumerable<BaseEntry> Entries => this.entries;

    public void Add(GlobalBgmEntry globalBgm)
    {
        this.entries.Add(globalBgm);
        if (globalBgm.Target is int bgmId)
        {
            this[bgmId] = globalBgm.Music;
        }
        else if (globalBgm.Target is string songName)
        {
            var songBgmId = resources.Songs[songName];
            this[songBgmId] = globalBgm.Music;
        }
    }
}
