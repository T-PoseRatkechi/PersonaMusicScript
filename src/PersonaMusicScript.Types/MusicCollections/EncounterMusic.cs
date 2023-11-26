using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Types.MusicCollections;

public class EncounterMusic : Dictionary<int, EncounterEntry>, IMusicEntries
{
    private readonly MusicResources resources;
    private readonly List<EncounterEntry> entries = new();

    public EncounterMusic(MusicResources resources)
    {
        this.resources = resources;
    }

    public IEnumerable<BaseEntry> Entries => this.entries;

    public void Add(EncounterEntry encounter)
    {
        this.entries.Add(encounter);
        if (encounter.Target is int encounterId)
        {
            this[encounterId] = encounter;
        }
        else if (encounter.Target is string collectionName)
        {
            var collection = resources.Collections[collectionName];
            foreach (var id in collection)
            {
                this[id] = encounter;
            }
        }
    }
}
