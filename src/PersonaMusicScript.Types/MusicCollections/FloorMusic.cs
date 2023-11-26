using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Types.MusicCollections;

public class FloorMusic : Dictionary<int, IMusic>, IMusicEntries
{
    private readonly MusicResources resources;
    private readonly List<BaseEntry> entries = new();

    public FloorMusic(MusicResources resources)
    {
        this.resources = resources;
    }

    public IEnumerable<BaseEntry> Entries => this.entries;

    public void Add(FloorEntry floor)
    {
        this.entries.Add(floor);
        if (floor.Target is int floorId)
        {
            this[floorId] = floor.Music;
        }
        else if (floor.Target is string collectionName)
        {
            var collection = resources.Collections[collectionName];
            foreach (var id in collection)
            {
                this[id] = floor.Music;
            }
        }
    }
}
