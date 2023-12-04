namespace PersonaMusicScript.Types.Music;

public class RandomMusic : IMusic
{
    private readonly IMusic[] musicItems;

    public RandomMusic(IMusic[] musicItems)
    {
        this.musicItems = musicItems;
    }

    public MusicType Type { get; } = MusicType.RandomMusic;

    public IMusic GetRandomMusic()
    {
        var randomIndex = Random.Shared.Next(0, musicItems.Length);
        return this.musicItems[randomIndex];
    }
}
