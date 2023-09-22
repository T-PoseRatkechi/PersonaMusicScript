namespace PersonaMusicScript.Library.Compiler;

public class SongUse
{
    public SongUse(int id)
    {
        AudioId = id;
    }

    public int AudioId { get; }

    public List<string> UsedBy { get; } = new List<string>();
}