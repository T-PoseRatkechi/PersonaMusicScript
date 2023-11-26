namespace PersonaMusicScript.Types.MusicCollections.Entries;

public abstract class BaseEntry
{
    public BaseEntry(object target)
    {
        this.Target = target;
    }

    public string? Name { get; set; }

    public object Target { get; set; }
}
