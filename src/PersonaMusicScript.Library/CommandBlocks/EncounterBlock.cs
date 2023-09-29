﻿using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;
using System.Runtime.CompilerServices;

namespace PersonaMusicScript.Library.CommandBlocks;

public class EncounterBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Encounter;

    public void Process(Music music, CommandBlock block)
    {
        if (block.Arg is int encounterId)
        {
            SetEncounterMusic(music, encounterId, block.Commands);
        }
        else if (block.Arg is string collectionName)
        {
            if (music.Resources.Collections.TryGetValue(collectionName, out var ids))
            {
                foreach (var id in ids)
                {
                    SetEncounterMusic(music, id, block.Commands);
                }
            }
            else if (collectionName.ToLower() == "all")
            {
                for (int i = 0; i < music.Resources.Constants.TotalEncounters; i++)
                {
                    SetEncounterMusic(music, i, block.Commands);
                }
            }
            else
            {
                throw new Exception($"Unknown collection name \"{collectionName}\".");
            }
        }
        else
        {
            throw new Exception($"Invalid encounter block arg \"{block.Arg}\".");
        }
    }

    private static void SetEncounterMusic(Music music, int encounterId, IEnumerable<Command> commands)
    {
        if (!music.Encounters.TryGetValue(encounterId, out var encounter))
        {
            encounter = new(encounterId);
            music.Encounters.Add(encounterId, encounter);
        }

        IMusic? normalBgm = null;
        IMusic? advantageBgm = null;
        IMusic? disadvantageBgm = null;

        IMusic? victoryNormalBgm = null;
        IMusic? victoryAdvantageBgm = null;
        IMusic? victoryDisadvantageBgm = null;

        foreach (var command in commands)
        {
            var musicType = CommandUtils.GetMusicType(command.Value);
            var musicId = CommandUtils.GetMusicId(command.Value);

            switch (command.Name)
            {
                case "music":
                    encounter.Field04_1 = musicType;
                    encounter.Music = (ushort)musicId;
                    break;
                case "victory_music":
                    encounter.Field04_2 = musicType;
                    encounter.Field06 = (ushort)musicId;
                    break;
                case "normal_bgm":
                    normalBgm = command.Value as IMusic;
                    break;
                case "advantage_bgm":
                    advantageBgm = command.Value as IMusic;
                    break;
                case "disadvantage_bgm":
                    disadvantageBgm = command.Value as IMusic;
                    break;
                case "victory_normal_bgm":
                    victoryNormalBgm = command.Value as IMusic;
                    break;
                case "victory_advantage_bgm":
                    victoryAdvantageBgm = command.Value as IMusic;
                    break;
                case "victory_disadvantage_bgm":
                    victoryDisadvantageBgm = command.Value as IMusic;
                    break;
                default:
                    throw new Exception($"Unknown command \"{command.Name}\".");

            }
        }

        if (normalBgm != null
            || advantageBgm != null
            || disadvantageBgm != null)
        {
            var battleBgm = new BattleBgm(music.Resources, music.Source, normalBgm, advantageBgm, disadvantageBgm);
            encounter.Field04_1 = MusicType.BattleBgm;
            encounter.Music = (ushort)battleBgm.Id;
        }

        if (victoryNormalBgm != null
            || victoryAdvantageBgm != null
            || victoryDisadvantageBgm != null)
        {
            var battleBgm = new BattleBgm(
                music.Resources,
                music.Source,
                victoryNormalBgm ?? music.Resources.Constants.DefaultVictoryMusic,
                victoryAdvantageBgm ?? music.Resources.Constants.DefaultVictoryMusic,
                victoryDisadvantageBgm ?? music.Resources.Constants.DefaultVictoryMusic);
            encounter.Field04_2 = MusicType.BattleBgm;
            encounter.Field06 = (ushort)battleBgm.Id;
        }
    }
}
