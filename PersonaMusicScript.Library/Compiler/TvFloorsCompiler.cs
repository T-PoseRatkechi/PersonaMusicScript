namespace PersonaMusicScript.Library.Compiler;

public class TvFloorsCompiler : IMusicCompiler
{
    public void Compile(Music music, List<string> patch, string outputDir)
    {
        var tvMusic = new List<ushort>(music.Resources.TvFloorsMusic);
        foreach (var floor in music.Floors)
        {
            tvMusic[floor.Id] = floor.Music;
        }

        var tvBgmsIndex = patch.FindIndex(x => x.StartsWith("var tvBgms"));
        if (tvBgmsIndex == -1)
        {
            throw new Exception("Failed to find var tvBgms");
        }

        var tvBgmBytes = tvMusic.SelectMany(BitConverter.GetBytes).ToArray();
        patch[tvBgmsIndex] = $"var tvBgms({tvBgmBytes.Length}) = bytes({Convert.ToHexString(tvBgmBytes)})";
    }
}
