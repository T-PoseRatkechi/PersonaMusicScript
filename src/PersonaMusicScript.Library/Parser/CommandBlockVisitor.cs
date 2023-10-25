using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.CommandBlocks;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser;

internal class CommandBlockVisitor : SourceBaseVisitor<bool>
{
    private readonly Dictionary<CommandBlockType, ICommandBlock> commandBlocks = new();

    private readonly MusicSource source;
    private readonly ExpressionVisitor expressionVisitor;
    private readonly CommandVisitor commandVisitor;

    public CommandBlockVisitor(
        MusicResources resources,
        MusicSource source,
        ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.expressionVisitor = expressionVisitor;
        this.commandVisitor = new(expressionVisitor);

        this.AddBlock(new EncounterBlock(resources));
        this.AddBlock(new EventBlock());
        this.AddBlock(new TvFloorBlock(resources));
        this.AddBlock(new GlobalBgmBlock(resources));
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

        if (commandBlocks.TryGetValue(type, out var commandBlock))
        {
            commandBlock.Process(this.source, new(type, arg, commands.ToArray()));
            return true;
        }

        return false;
    }

    private void AddBlock(ICommandBlock block)
    {
        this.commandBlocks.Add(block.Type, block);
    }
}
