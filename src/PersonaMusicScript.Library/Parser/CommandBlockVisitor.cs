using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.CommandBlocks;
using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class CommandBlockVisitor : SourceBaseVisitor<bool>
{
    private readonly Dictionary<CommandBlockType, ICommandBlock> commandBlocks = new()
    {
        [CommandBlockType.Global_Bgm] = new GlobalBgmBlock(),
        [CommandBlockType.Encounter] = new EncounterBlock(),
        [CommandBlockType.Event] = new EventBlock(),
        [CommandBlockType.Floor] = new FloorBlock(),
    };

    private readonly MusicSource source;
    private readonly ExpressionVisitor expressionVisitor;
    private readonly CommandVisitor commandVisitor;

    public CommandBlockVisitor(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.expressionVisitor = expressionVisitor;
        this.commandVisitor = new(expressionVisitor);
    }

    public override bool VisitCommandBlock([NotNull] SourceParser.CommandBlockContext context)
    {
        var typeString = context.ID().GetText();
        var type = Enum.Parse<CommandBlockType>(typeString, true);
        var arg = this.expressionVisitor.Visit(context.expression());

        var commands = new List<Command>();
        foreach (var commandCtx in context.command())
        {
            var command = this.commandVisitor.Visit(commandCtx);
            commands.Add(command);
        }

        if (this.commandBlocks.TryGetValue(type, out var commandBlock))
        {
            var result = commandBlock.GetResult(arg, commands.ToArray());
            this.source.AddEntry(result);
            return true;
        }


        throw new ParsingException($"Unknown command block type: {typeString}", context);
    }
}
