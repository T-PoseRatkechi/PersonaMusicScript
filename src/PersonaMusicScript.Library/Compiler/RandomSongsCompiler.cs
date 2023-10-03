namespace PersonaMusicScript.Library.Compiler;

public class RandomSongsCompiler : IMusicCompiler
{
    public void Compile(Music music, List<string> patch, string outputDir)
    {
        // Create random songs data var.
        var randomSongsBytes = new List<byte>();
        foreach (var randomSong in music.Source.RandomSongs)
        {
            var minBytes = BitConverter.GetBytes((ushort)randomSong.MinSongId);
            var maxBytes = BitConverter.GetBytes((ushort)randomSong.MaxSongId);
            randomSongsBytes.AddRange(minBytes);
            randomSongsBytes.AddRange(maxBytes);
        }

        if (randomSongsBytes.Count == 0)
        {
            randomSongsBytes.Add(0x00);
        }

        var randomSongsVar = $"var randomSongs({randomSongsBytes.Count}) = bytes({Convert.ToHexString(randomSongsBytes.ToArray())})";
        patch.Insert(0, randomSongsVar);
    }
}
