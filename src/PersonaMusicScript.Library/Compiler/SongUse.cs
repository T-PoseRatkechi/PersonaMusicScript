namespace PersonaMusicScript.Library.Compiler;

public class SongUse
{
    public SongUse(int id)
    {
        AudioId = id;
    }

    public int AudioId { get; }

    public HashSet<string> UsedBy { get; } = new HashSet<string>();
}