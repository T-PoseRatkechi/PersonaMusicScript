namespace PersonaMusicScript.Library.Models;

public class RandomSong : IMusic
{
    private readonly MusicSource source;

    public RandomSong(MusicSource source, int min, int max)
    {
        this.source = source;
        this.MinSongId = min;
        this.MaxSongId = max;
        if (!source.RandomSongs.Contains(this))
        {
            source.RandomSongs.Add(this);
        }
    }

    public int Id => this.source.RandomSongs.IndexOf(this);

    public MusicType Type { get; } = MusicType.RandomSong;

    public int MinSongId { get; set; }

    public int MaxSongId { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is RandomSong other)
        {
            if (this.MinSongId == other.MinSongId
                && this.MaxSongId == other.MaxSongId)
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