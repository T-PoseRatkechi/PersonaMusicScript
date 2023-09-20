using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public Dictionary<string, object> Constants { get; } = new();

    public List<CommandBlock> Blocks { get; } = new();
}
