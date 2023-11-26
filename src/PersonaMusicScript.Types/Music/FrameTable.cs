namespace PersonaMusicScript.Types.Music;

public class FrameTable
{
    public FrameTable(int majorId, int minorId, PmdType pmdType = PmdType.PM3)
    {
        this.Ids = new(majorId, minorId, pmdType);
    }

    public FrameTable(string eventFile, int majorId = 0, int minorId = 0, PmdType pmdType = PmdType.PM3)
    {
        this.EventFile = eventFile;
        this.Ids = new(majorId, minorId, pmdType);
    }

    public string? EventFile { get; }

    public EventIds Ids { get; }

    public Dictionary<int, IMusic?> Frames { get; } = new();
}

public record EventIds(int MajorId, int MinorId, PmdType PmdType);