namespace PersonaMusicScript.Library.Models;

public class EventFrame
{
    public EventFrame(int majorId, int minorId)
    {
        this.Ids = new(majorId, minorId);
    }

    public EventFrame(string eventFile, int majorId = 0, int minorId = 0)
    {
        this.EventFile = eventFile;
        this.Ids = new(majorId, minorId);
    }

    public string? EventFile { get; }

    public EventIds Ids { get; }

    public Dictionary<int, IMusic?> FrameMusic { get; } = new();
}

public record EventIds(int MajorId, int MinorId);
