using PersonaMusicScript.Library.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public static class CommandUtils
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

    public static int GetMusicId(object value)
    {
        if (value is int songId)
        {
            return songId;
        }
        else if (value is IMusic music)
        {
            return music.Id;
        }
        else
        {
            throw new ArgumentException("Invalid music value.");
        }
    }
}
