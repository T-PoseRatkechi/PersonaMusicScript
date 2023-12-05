using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Functions;
using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types;

namespace PersonaMusicScript.Library.Parser;

internal class SourceVisitor : SourceBaseVisitor<MusicScript>
{
    private readonly FunctionTable functions = new();
    private readonly ConstantTable constants = new();
    private readonly MusicResources resources;
    private readonly MusicSource source;

    public SourceVisitor(MusicResources resources, MusicSource? source = null)
    {
        this.source = source ?? new(resources);
        this.resources = resources;
    }

    public override MusicScript VisitSource([NotNull] SourceParser.SourceContext context)
    {
        var functionVisitor = new FunctionVisitor(this.functions);
        var expressionVisitor = new ExpressionVisitor(this.constants, functionVisitor);
        var assignmentVisitor = new AssignmentVisitor(this.constants, expressionVisitor);
        var commandBlockVisitor = new CommandBlockVisitor(this.source, expressionVisitor);
        var statementVisitor = new StatementVisitor(assignmentVisitor, commandBlockVisitor);

        this.functions.Add(new BattleBgmFunction(expressionVisitor));
        this.functions.Add(new SongFunction(this.resources, expressionVisitor));
        this.functions.Add(new RandomSongFunction(expressionVisitor));
        this.functions.Add(new EventFunction(expressionVisitor));
        this.functions.Add(new SoundFunction(expressionVisitor));
        this.functions.Add(new FrameBgmFunction(expressionVisitor));
        this.functions.Add(new BattleVictorySetFunction(expressionVisitor));
        this.functions.Add(new RandomMusicFunction(expressionVisitor));

        foreach (var statement in context.statement())
        {
            if (!statementVisitor.Visit(statement))
            {
                throw new ParsingException("Failed to parse statement.", statement);
            }
        }

        return new(this.resources, this.constants, this.source);
    }
}
