using Antlr4.Runtime;
using PersonaMusicScript.Library.Compiler;
using PersonaMusicScript.Library.Parser;

namespace PersonaMusicScript.Library;

public class MusicParser
{
    private readonly MusicResources resources;

    public MusicParser(string game)
    {
        this.resources = new(game);
    }

    public Music Parse(string inputFile, string? outputDir = null)
    {
        var inputStream = new AntlrInputStream(File.ReadAllText(inputFile));
        var lexer = new SourceLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var sourceParser = new SourceParser(tokens);

        var visitor = new SourceVisitor(this.resources);
        var sourceCtx = sourceParser.source();
        var musicSource = visitor.Visit(sourceCtx);
        var music = new Music(musicSource, this.resources);

        var outputFolder = outputDir ?? Path.Join(AppDomain.CurrentDomain.BaseDirectory, "output");
        Directory.CreateDirectory(outputFolder);

        var musicCompiler = new MusicCompiler(this.resources, musicSource);
        musicCompiler.Compile(music, outputFolder);

        var outputPresetFile = Path.Join(outputFolder, "BGME.project");
        MusicPreset.Create(music, outputPresetFile);
        return music;
    }
}
