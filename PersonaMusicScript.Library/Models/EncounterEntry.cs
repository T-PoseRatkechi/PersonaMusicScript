namespace PersonaMusicScript.Library.Models;

public class EncounterEntry
{
    public EncounterEntry(int id)
    {
        Index = id;
    }

    /// <summary>
    /// Encounter entry index in ENCOUNT tbl.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Battle BGM type.
    /// </summary>
    public MusicType Field04_1 { get; set; }

    /// <summary>
    /// Victory BGM type.
    /// </summary>
    public MusicType Field04_2 { get; set; }

    /// <summary>
    /// Victory Music ID.
    /// </summary>
    public ushort Field06 { get; set; }

    /// <summary>
    /// Battle Music ID.
    /// </summary>
    public ushort Music { get; set; }
}