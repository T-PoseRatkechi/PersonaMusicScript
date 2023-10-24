using PersonaMusicScript.Library.Models;

namespace PersonaMusicScript.Library;

public class MusicSource
{
    public Dictionary<int, Encounter> Encounters { get; } = new();

    public Dictionary<int, IMusic> Floors { get; } = new();

    public Dictionary<string, EventFrame> Events { get; } = new();
}
