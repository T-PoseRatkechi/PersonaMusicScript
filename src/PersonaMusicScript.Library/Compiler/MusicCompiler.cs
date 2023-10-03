namespace PersonaMusicScript.Library.Compiler;

public class MusicCompiler
{
    private readonly EncounterMusicCompiler encounterMusic = new();
    private readonly RandomSongsCompiler randomSongs = new();
    private readonly BattleBgmsCompiler battleBgms = new();
    private readonly EventsCompiler events = new();
    private readonly TvFloorsCompiler tv = new();

    public void Compile(Music music, string outputDir)
    {
        var patch = new List<string>(File.ReadAllLines(music.Resources.PatchFile));
        this.encounterMusic.Compile(music, patch, outputDir);
        this.randomSongs.Compile(music, patch, outputDir);
        this.battleBgms.Compile(music, patch, outputDir);
        this.events.Compile(music, patch, outputDir);
        this.tv.Compile(music, patch, outputDir);

        var outputFile = Path.Join(outputDir, Path.GetFileName(music.Resources.PatchFile));
        File.WriteAllLines(outputFile, patch);
    }
}
