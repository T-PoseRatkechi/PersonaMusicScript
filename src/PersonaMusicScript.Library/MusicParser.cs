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

    public Music Parse(string inputFile)
    {
        var inputStream = new AntlrInputStream(File.ReadAllText(inputFile));
        var lexer = new SourceLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var sourceParser = new SourceParser(tokens);

        var visitor = new SourceVisitor(this.resources);
        var sourceCtx = sourceParser.source();
        var musicSource = visitor.Visit(sourceCtx);
        var music = new Music(musicSource, this.resources);

        var outputFolder = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "output");
        if (Directory.Exists(outputFolder))
        {
            Directory.Delete(outputFolder, true);
        }

        Directory.CreateDirectory(outputFolder);

        var musicCompiler = new MusicCompiler();
        musicCompiler.Compile(music, outputFolder);

        var presetName = Path.GetFileNameWithoutExtension(inputFile) ?? "BGME";
        var outputPresetFile = Path.Join(outputFolder, $"{presetName}.project");
        MusicPreset.Create(music, outputPresetFile);
        return music;
    }
}
