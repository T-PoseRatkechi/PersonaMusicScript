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

        var fileName = Path.GetFileNameWithoutExtension(inputFile) ?? "BGME";
        var inputFolder = Path.GetDirectoryName(Path.GetFullPath(inputFile)) ?? AppDomain.CurrentDomain.BaseDirectory;
        var outputFolder = Path.Join(inputFolder, fileName);
        if (outputFolder.Length < "BGME".Length)
        {
            throw new Exception($"Output folder path shorter than expected. Path: {outputFolder}");
        }

        if (Directory.Exists(outputFolder))
        {
            Directory.Delete(outputFolder, true);
        }

        Directory.CreateDirectory(outputFolder);

        var musicCompiler = new MusicCompiler();
        musicCompiler.Compile(music, outputFolder);

        var outputPresetFile = Path.Join(outputFolder, $"{fileName}.project");
        MusicPreset.Create(music, outputPresetFile);
        return music;
    }
}
