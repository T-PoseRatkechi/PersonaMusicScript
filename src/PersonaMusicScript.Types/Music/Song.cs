namespace PersonaMusicScript.Types.Music;

public class Song : IMusic
{
    public Song(int id) => this.Id = id;

    public Song(MusicResources resources, string name)
    {
        if (resources.Songs.TryGetValue(name, out var id))
        {
            this.Id = id;
        }
        else
        {
            throw new ArgumentException($"Song with name \"{name}\" not found.");
        }
    }

    public MusicType Type { get; } = MusicType.Song;

    public int Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj is Song other)
        {
            if (this.Id == other.Id)
            {
                return true;
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
