using PersonaMusicScript.Library.Models.Music.Entries;

namespace PersonaMusicScript.Library.Models.Music;

internal interface IMusicEntries
{
    IEnumerable<BaseEntry> Entries { get; }
}
