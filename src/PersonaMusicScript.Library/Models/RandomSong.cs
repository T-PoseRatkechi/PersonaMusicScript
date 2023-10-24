namespace PersonaMusicScript.Library.Models;

public class RandomSong : IMusic
{
    public RandomSong(int min, int max)
    {
        this.MinSongId = min;
        this.MaxSongId = max + 1;
    }

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