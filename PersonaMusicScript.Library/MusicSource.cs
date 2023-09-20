using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public List<RandomSong> RandomSongs { get; } = new();

    public List<SituationalBgm> SituationalBgms { get; } = new();

    public Dictionary<string, object> Constants { get; } = new();

    public List<CommandBlock> Blocks { get; } = new();
}
