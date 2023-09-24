using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library;

public class Music
{
    public Music(MusicSource source, MusicResources resources)
    {
        this.Source = source;
        this.Resources = resources;
        this.ProcessMusic();
    }

    public MusicSource Source { get; }

    public MusicResources Resources { get; }

    public List<EncounterEntry> Encounters { get; } = new();

    private void ProcessMusic()
    {
        foreach (var block in this.Source.Blocks)
        {
            if (block.Type == CommandBlockType.Encounter)
            {
                if (block.Arg is int encounterId)
                {
                    var encounter = this.CreateEncounter(encounterId, block.Commands);
                    this.Encounters.Add(encounter);
                }
                else if (block.Arg is string collectionName)
                {
                    if (this.Resources.Collections.TryGetValue(collectionName, out var ids))
                    {
                        foreach (var id in ids)
                        {
                            var encounter = this.CreateEncounter(id, block.Commands);
                            this.Encounters.Add(encounter);
                        }
                    }
                    else if (collectionName.ToLower() == "all")
                    {
                        for (int i = 0; i < this.Resources.Constants.TotalEncounters; i++)
                        {
                            var encounter = this.CreateEncounter(i, block.Commands);
                            this.Encounters.Add(encounter);
                        }
                    }
                }
                else
                {
                    throw new Exception($"Invalid command block arg \"{block.Arg}\".");
                }
            }
        }
    }

    private EncounterEntry CreateEncounter(int encounterId, IEnumerable<Command> commands)
    {
        var encounter = new EncounterEntry(encounterId);
        IMusic? normalBgm = null;
        IMusic? advantageBgm = null;
        IMusic? disadvantageBgm = null;

        foreach (var command in commands)
        {
            var musicType = this.GetMusicType(command.Value);
            var musicId = this.GetMusicId(command.Value);
            if (command.Name == "music")
            {
                encounter.Field04_1 = musicType;
                encounter.Music = (ushort)musicId;
            }
            else if (command.Name == "victory_music")
            {
                encounter.Field04_2 = musicType;
                encounter.Field06 = (ushort)musicId;
            }
            else if (command.Name == "normal_bgm")
            {
                normalBgm = command.Value as IMusic;
            }
            else if (command.Name == "advantage_bgm")
            {
                advantageBgm = command.Value as IMusic;
            }
            else if (command.Name == "disadvantage_bgm")
            {
                disadvantageBgm = command.Value as IMusic;
            }
            else
            {
                throw new Exception($"Unknown command \"{command.Name}\".");
            }
        }

        if (normalBgm != null
            || advantageBgm != null
            || disadvantageBgm != null)
        {
            var battleBgm = new BattleBgm(this.Resources, this.Source, normalBgm, advantageBgm, disadvantageBgm);
            encounter.Field04_1 = MusicType.BattleBgm;
            encounter.Music = (ushort)battleBgm.Id;
        }

        return encounter;
    }

    private MusicType GetMusicType(object value)
    {
        if (value is int)
        {
            return MusicType.Song;
        }
        else if (value is IMusic music)
        {
            return music.Type;
        }

        throw new Exception("Invalid music type.");
    }

    private int GetMusicId(object value)
    {
        if (value is int songId)
        {
            return songId;
        }
        else if (value is IMusic music)
        {
            return music.Id;
        }
        else
        {
            throw new ArgumentException("Invalid music value.");
        }
    }
}
