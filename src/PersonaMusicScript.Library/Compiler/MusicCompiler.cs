namespace PersonaMusicScript.Library.Compiler;

public class MusicCompiler
{
    private readonly EncountersCompiler encounters;
    private readonly EventsCompiler events;
    private readonly TvFloorsCompiler tv;

    public MusicCompiler()
    {
        this.encounters = new();
        this.events = new();
        this.tv = new();
    }

    public void Compile(Music music, string outputDir)
    {
        var patch = new List<string>(File.ReadAllLines(music.Resources.PatchFile));
        this.encounters.Compile(music, patch, outputDir);
        this.events.Compile(music, patch, outputDir);
        this.tv.Compile(music, patch, outputDir);

        var outputFile = Path.Join(outputDir, Path.GetFileName(music.Resources.PatchFile));
        File.WriteAllLines(outputFile, patch);
    }
}
