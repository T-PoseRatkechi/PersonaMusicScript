using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Types.MusicCollections;

public static class MusicUtils
{
    public static MusicType GetMusicType(object value)
    {
        if (value is int)
        {
            return MusicType.Song;
        }
        else if (value is IMusic music)
        {
            return music.Type;
        }

        throw new Exception("Invalid music type.");
    }

    public static IMusic GetMusic(object value)
    {
        if (value is IMusic music)
        {
            return music;
        }
        else if (value is int songId)
        {
            return new Song(songId);
        }
        else
        {
            throw new ArgumentException("Invalid music value.");
        }
    }
}
