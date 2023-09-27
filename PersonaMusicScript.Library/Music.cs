using PersonaMusicScript.Library.CommandBlocks;
using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library;

public class Music
{
    private readonly ICommandBlock[] commandBlocks = new ICommandBlock[]
    {
        new EncounterBlock(),
        new EventBlock(),
        new TvFloorBlock(),
    };

    public Music(MusicSource source, MusicResources resources)
    {
        this.Source = source;
        this.Resources = resources;
        this.ProcessMusic();
    }

    public MusicSource Source { get; }

    public MusicResources Resources { get; }

    public List<EncounterEntry> Encounters { get; } = new();

    public Dictionary<string, EventFrame> Events { get; } = new();

    public HashSet<TvFloor> Floors { get; } = new();

    private void ProcessMusic()
    {
        // Set all battle victory BGMs to default.
        var victoryBgmCommand = new Command[]
        {
            new Command("victory_music", this.Resources.Constants.DefaultVictoryMusic)
        };

        this.Source.Blocks.Insert(0, new(CommandBlockType.Encounter, "all", victoryBgmCommand));
        foreach (var block in this.Source.Blocks)
        {
            this.commandBlocks.First(x => x.Type == block.Type).Process(this, block);
        }
    }
}
