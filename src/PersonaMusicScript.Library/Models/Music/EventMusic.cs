using PersonaMusicScript.Library.Models.Music.Entries;

namespace PersonaMusicScript.Library.Models.Music;

public class EventMusic : Dictionary<EventIds, FrameTable>, IMusicEntries
{
    private readonly List<BaseEntry> entries = new();

    public IEnumerable<BaseEntry> Entries => this.entries;

    public void Add(EventEntry entry)
    {
        this.entries.Add(entry);
        if (entry.Target is FrameTable frame)
        {
            this[frame.Ids] = frame;
        }
    }

    public FrameTable? GetEventFrame(int majorId, int minorId, PmdType pmdType)
    {
        if (TryGetValue(new(majorId, minorId, pmdType), out var frame))
        {
            return frame;
        }

        return null;
    }

    public FrameTable? GetEventFrame(EventIds ids)
    {
        if (TryGetValue(ids, out var frame))
        {
            return frame;
        }

        return null;
    }
}
