using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal class EncounterBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Encounter;

    public BaseEntry GetResult(object arg, IEnumerable<Command> commands)
    {
        EncounterEntry? result;
        if (arg is int encounterId)
        {
            result = new(encounterId);
        }
        else if (arg is string collectionName)
        {
            result = new(collectionName);
        }
        else
        {
            throw new InvalidArgException(arg);
        }

        SetEncounterMusic(result, commands);
        return result;
    }

    private static void SetEncounterMusic(EncounterEntry encounter, IEnumerable<Command> commands)
    {
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

            var musicType = MusicUtils.GetMusicType(command.Value);
            var musicValue = MusicUtils.GetMusic(command.Value);

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
