using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Types.MusicCollections;

internal interface IMusicEntries
{
    IEnumerable<BaseEntry> Entries { get; }
}
