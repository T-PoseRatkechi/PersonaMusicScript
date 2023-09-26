namespace PersonaMusicScript.Library.Compiler;

public class MusicCompiler : IMusicCompiler
{
    private readonly EncountersCompiler encounters;
    private readonly EventsCompiler events;

    public MusicCompiler()
    {
        this.encounters = new();
        this.events = new();
    }

    public void Compile(Music music, string outputDir)
    {
        this.encounters.Compile(music, outputDir);
        this.events.Compile(music, outputDir);
    }
}
