using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Types;
using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class SongFunction : IFunction<Song>
{
    private readonly MusicResources resources;
    private readonly ExpressionVisitor expressionVisitor;

    public SongFunction(MusicResources resources, ExpressionVisitor expressionVisitor)
    {
        this.resources = resources;
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "song";

    public Song Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 1, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length != 1)
        {
            throw new FunctionException(this.Name, 1, argExps.Length, context);
        }

        var argValue = this.expressionVisitor.Visit(argExps[0]);
        if (argValue is int id)
        {
            return new Song(id);
        }
        
        if (argValue is string name)
        {
            return new Song(this.resources, name);
        }

        throw new ParsingException("Invalid function argument.", context);
    }
}
