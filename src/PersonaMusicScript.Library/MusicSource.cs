using PersonaMusicScript.Types;
using PersonaMusicScript.Types.MusicCollections;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public MusicSource(MusicResources resources)
    {
        this.Encounters = new(resources);
        this.Floors = new(resources);
        this.Global = new(resources);
        this.Events = new();
    }

    public EncounterMusic Encounters { get; }

    public FloorMusic Floors { get; }

    public GlobalMusic Global { get; }

    public EventMusic Events { get; }

    public void AddEntry(BaseEntry entry)
    {
        if (entry is EncounterEntry encounter)
        {
            this.Encounters.Add(encounter);
        }
        else if (entry is FloorEntry floor)
        {
            this.Floors.Add(floor);
        }
        else if (entry is GlobalBgmEntry global)
        {
            this.Global.Add(global);
        }
        else if (entry is EventEntry eventEntry)
        {
            this.Events.Add(eventEntry);
        }
    }
}
