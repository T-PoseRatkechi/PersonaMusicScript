using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public class TvFloorBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.TV_Floor;

    public void Process(Music music, CommandBlock block)
    {
        if (block.Arg is int floorId)
        {
            CreateFloorBgm(music, floorId, block.Commands);
        }
        else if (block.Arg is string collectionName)
        {
            if (music.Resources.Collections.TryGetValue(collectionName, out var ids))
            {
                foreach (var id in ids)
                {
                    CreateFloorBgm(music, id, block.Commands);
                }
            }
            else if (collectionName.ToLower() == "all")
            {
                for (int i = 0; i < music.Resources.TvFloorsMusic.Count; i++)
                {
                    CreateFloorBgm(music, i, block.Commands);
                }
            }
        }
        else
        {
            throw new Exception($"Invalid tv floor block arg \"{block.Arg}\".");
        }
    }

    private static void CreateFloorBgm(Music music, int floorId, IEnumerable<Command> commands)
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

            var musicId = CommandUtils.GetMusicId(command.Value);
            music.Floors.Add(new(floorId, (ushort)musicId));
        }
    }
}
