namespace PersonaMusicScript.Types.Music;

public class RandomSong : IMusic
{
    /// <summary>
    /// Randomly selects a BGM ID from a range of IDs, inclusive.
    /// </summary>
    /// <param name="min">Min BGM ID.</param>
    /// <param name="max">Max BGM ID.</param>
    public RandomSong(int min, int max)
    {
        this.MinSongId = min;
        this.MaxSongId = max + 1;
    }

    /// <summary>
    /// Randomly selects a BGM ID from a list of BGM IDs.
    /// </summary>
    /// <param name="bgmIds">List of BGM IDs.</param>
    public RandomSong(int[] bgmIds)
    {
        this.BgmIds = bgmIds;
    }

    public MusicType Type { get; } = MusicType.RandomSong;

    public int MinSongId { get; set; }

    public int MaxSongId { get; set; }

    public int[]? BgmIds { get; set; }

    public int GetRandomId()
    {
        if (this.BgmIds != null)
        {
            var index = Random.Shared.Next(0, BgmIds.Length);
            return this.BgmIds[index];
        }

        return Random.Shared.Next(this.MinSongId, this.MaxSongId);
    }

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