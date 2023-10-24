using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public class TvFloorBlock : ICommandBlock
{
    private readonly MusicResources resources;

    public TvFloorBlock(MusicResources resources)
    {
        this.resources = resources;
    }

    public CommandBlockType Type { get; } = CommandBlockType.Floor;

    public void Process(MusicSource source, CommandBlock block)
    {
        if (block.Arg is int floorId)
        {
            AddFloorBgm(source, floorId, block.Commands);
        }
        else if (block.Arg is string collectionName)
        {
            if (this.resources.Collections.TryGetValue(collectionName, out var ids))
            {
                foreach (var id in ids)
                {
                    AddFloorBgm(source, id, block.Commands);
                }
            }
            else if (collectionName.ToLower() == "all")
            {
                for (int i = 0; i < this.resources.TvFloorsMusic.Count; i++)
                {
                    AddFloorBgm(source, i, block.Commands);
                }
            }
            else
            {
                throw new Exception($"Unknown collection name \"{collectionName}\".");
            }
        }
        else
        {
            throw new Exception($"Invalid tv floor block arg \"{block.Arg}\".");
        }
    }

    private static void AddFloorBgm(MusicSource source, int floorId, IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            if (command.Name != "music")
            {
                throw new Exception($"Invalid tv floor command \"{command.Name}\".");
            }

            if (command.Value is not int && command.Value is not Song)
            {
                throw new Exception($"Invalid tv floor music type.");
            }

            var musicValue = CommandUtils.GetMusic(command.Value);
            if (source.Floors.ContainsKey(floorId))
            {
                source.Floors[floorId] = musicValue;
            }
            else
            {
                source.Floors.Add(floorId, musicValue);
            }
        }
    }
}
