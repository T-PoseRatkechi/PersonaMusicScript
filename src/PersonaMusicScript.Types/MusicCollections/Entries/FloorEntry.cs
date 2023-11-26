using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Types.MusicCollections.Entries;

public class FloorEntry : BaseEntry
{
    public FloorEntry(int floorId, IMusic music)
        : base(floorId)
    {
        this.Name = $"Floor: {floorId}";
        this.Music = music;
    }

    public FloorEntry(string collection, IMusic music)
        : base(collection)
    {
        this.Name = collection;
        this.Music = music;
    }

    public IMusic Music { get; set; }
}
