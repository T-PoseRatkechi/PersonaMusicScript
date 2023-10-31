using PersonaMusicScript.Library.Models;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public Dictionary<int, Encounter> Encounters { get; } = new();

    public Dictionary<int, IMusic> Floors { get; } = new();

    public Dictionary<EventIds, FrameTable> Events { get; } = new();

    public Dictionary<int, IMusic> Global { get; } = new();

    public void AddEventFrame(FrameTable frame)
    {
        this.Events.Add(frame.Ids, frame);
    }

    public FrameTable? GetEventFrame(int majorId, int minorId, PmdType pmdType)
    {
        if (this.Events.TryGetValue(new(majorId, minorId, pmdType), out var frame))
        {
            return frame;
        }

        return null;
    }

    public FrameTable? GetEventFrame(EventIds ids)
    {
        if (this.Events.TryGetValue(ids, out var frame))
        {
            return frame;
        }

        return null;
    }
}
