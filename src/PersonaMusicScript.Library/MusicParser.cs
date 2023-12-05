using Antlr4.Runtime;
using PersonaModdingMetadata.Shared.Games;
using PersonaMusicScript.Library.Parser;
using PersonaMusicScript.Library.Presets;
using PersonaMusicScript.Types;

namespace PersonaMusicScript.Library;

public class MusicParser
{
    private readonly MusicResources resources;
    private readonly PresetBuilder presetBuilder;

    public MusicParser(MusicResources resources)
    {
        this.resources = resources;
        this.presetBuilder = new(resources);
    }

    public MusicParser(Game game, string? resourcesDir = null)
    {
        this.resources = new(game, resourcesDir);
        this.presetBuilder = new(this.resources);
    }

    /// <summary>
    /// Parse music script from text file.
    /// </summary>
    /// <param name="inputFile">Input file path.</param>
    /// <param name="existingSource">Existing music source to apply script to.</param>
    /// <returns>Music source.</returns>
    public MusicScript ParseFile(string inputFile, MusicSource? existingSource = null)
        => this.Parse(File.ReadAllText(inputFile), existingSource);

    /// <summary>
    /// Parse music script.
    /// </summary>
    /// <param name="musicScriptText">Music script text.</param>
    /// <param name="existingSource">Existing music source to apply script to.</param>
    /// <returns>Music source.</returns>
    public MusicScript Parse(string musicScriptText, MusicSource? existingSource = null)
    {
        var inputStream = new AntlrInputStream(musicScriptText);
        var lexer = new SourceLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new SourceParser(tokens);
        var visitor = new SourceVisitor(this.resources, existingSource);

        var sourceCtx = parser.source();
        var musicScript = visitor.Visit(sourceCtx);
        return musicScript;
    }

    /// <summary>
    /// Create a project preset from a music script.
    /// </summary>
    /// <param name="inputFile">Input music script file.</param>
    /// <param name="outputFile">Output preset file.</param>
    public void CreatePreset(string inputFile, string outputFile)
    {
        var music = this.ParseFile(inputFile);
        this.presetBuilder.Create(music.Source, outputFile);
    }

    /// <summary>
    /// Create a project preset from a music source.
    /// </summary>
    /// <param name="source">Music source.</param>
    /// <param name="outputFile">Output preset file.</param>
    public void CreatePreset(MusicSource source, string outputFile)
    {
        this.presetBuilder.Create(source, outputFile);
    }
}
