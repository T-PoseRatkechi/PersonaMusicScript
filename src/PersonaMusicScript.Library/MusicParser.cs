using Antlr4.Runtime;
using PersonaMusicScript.Library.Parser;

namespace PersonaMusicScript.Library;

public class MusicParser
{
    private readonly MusicResources resources;

    public MusicParser(string game, string? resourcesDir = null)
    {
        this.resources = new(game, resourcesDir);
    }

    /// <summary>
    /// Parse music script from text file.
    /// </summary>
    /// <param name="inputFile">Input file path.</param>
    /// <param name="existingSource">Existing music source to apply script to.</param>
    /// <returns>Music source.</returns>
    public MusicSource ParseFile(string inputFile, MusicSource? existingSource = null)
    {
        var inputStream = new AntlrInputStream(File.ReadAllText(inputFile));
        var lexer = new SourceLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new SourceParser(tokens);
        var visitor = new SourceVisitor(this.resources, existingSource);

        var sourceCtx = parser.source();
        var source = visitor.Visit(sourceCtx);
        return source;
    }
}
