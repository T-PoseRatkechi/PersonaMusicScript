using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public class EncounterBlock : ICommandBlock
{
    private readonly MusicResources resources;

    public EncounterBlock(MusicResources resources)
    {
        this.resources = resources;
    }

    public CommandBlockType Type { get; } = CommandBlockType.Encounter;

    public void Process(MusicSource source, CommandBlock block)
    {
        if (block.Arg is int encounterId)
        {
            SetEncounterMusic(source, encounterId, block.Commands, $"Encounter: {encounterId}");
        }
        else if (block.Arg is string collection)
        {
            if (this.resources.Collections.TryGetValue(collection, out var ids))
            {
                foreach (var id in ids)
                {
                    SetEncounterMusic(source, id, block.Commands, collection);
                }
            }
            else if (collection.ToLower() == "all")
            {
                for (int i = 0; i < this.resources.Constants.TotalEncounters; i++)
                {
                    SetEncounterMusic(source, i, block.Commands);
                }
            }
            else
            {
                throw new Exception($"Unknown collection name \"{collection}\".");
            }
        }
        else
        {
            throw new Exception($"Invalid encounter block arg \"{block.Arg}\".");
        }
    }

    public static void SetEncounterMusic(MusicSource source, int encounterId, IEnumerable<Command> commands, string? name = null)
    {
        // Use existing encounter or create and add new one.
        if (!source.Encounters.TryGetValue(encounterId, out var encounter))
        {
            encounter = new()
            {
                Name = name,
            };

            source.Encounters.Add(encounterId, encounter);
        }

        // Add name if encounter previously added with all.
        encounter.Name ??= name;

        IMusic? normalBgm = null;
        IMusic? advantageBgm = null;
        IMusic? disadvantageBgm = null;

        IMusic? victoryNormalBgm = null;
        IMusic? victoryAdvantageBgm = null;
        IMusic? victoryDisadvantageBgm = null;

        foreach (var command in commands)
        {
            // Handle special values.
            if (command.Name == "music"
                && command.Value is string valueString
                && valueString == "default")
            {
                encounter.BattleMusic = null;
                continue;
            }

            var musicType = CommandUtils.GetMusicType(command.Value);
            var musicValue = CommandUtils.GetMusic(command.Value);

            switch (command.Name)
            {
                case "music":
                    encounter.BattleMusic = musicValue;
                    break;
                case "victory_music":
                    encounter.VictoryMusic = musicValue;
                    break;
                case "normal_bgm":
                    normalBgm = musicValue;
                    break;
                case "advantage_bgm":
                    advantageBgm = musicValue;
                    break;
                case "disadvantage_bgm":
                    disadvantageBgm = musicValue;
                    break;
                case "victory_normal_bgm":
                    victoryNormalBgm = musicValue;
                    break;
                case "victory_advantage_bgm":
                    victoryAdvantageBgm = musicValue;
                    break;
                case "victory_disadvantage_bgm":
                    victoryDisadvantageBgm = musicValue;
                    break;
                default:
                    throw new Exception($"Unknown command \"{command.Name}\".");
            }

            if (normalBgm != null
                || advantageBgm != null
                || disadvantageBgm != null)
            {
                encounter.BattleMusic = new BattleBgm(normalBgm, advantageBgm, disadvantageBgm);
            }

            if (victoryNormalBgm != null
                || victoryAdvantageBgm != null
                || victoryDisadvantageBgm != null)
            {
                encounter.VictoryMusic = new BattleBgm(
                    victoryNormalBgm,
                    victoryAdvantageBgm,
                    victoryDisadvantageBgm);
            }
        }
    }
}
