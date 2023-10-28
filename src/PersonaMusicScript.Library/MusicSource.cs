using PersonaMusicScript.Library.Models;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public Dictionary<int, Encounter> Encounters { get; } = new();

    public Dictionary<int, IMusic> Floors { get; } = new();

    public Dictionary<EventIds, EventFrame> Events { get; } = new();

    public Dictionary<int, IMusic> Global { get; } = new();

    public void AddEventFrame(EventFrame frame)
    {
        this.Events.Add(frame.Ids, frame);
    }

    public EventFrame? GetEventFrame(int majorId, int minorId)
    {
        if (this.Events.TryGetValue(new(majorId, minorId), out var frame))
        {
            return frame;
        }

        return null;
    }

    public EventFrame? GetEventFrame(EventIds ids)
    {
        if (this.Events.TryGetValue(ids, out var frame))
        {
            return frame;
        }

        return null;
    }
}
