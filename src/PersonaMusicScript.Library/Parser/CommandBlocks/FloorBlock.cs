using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal class FloorBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Floor;

    public BaseEntry GetResult(object arg, IEnumerable<Command> commands)
    {
        var music = GetFloorMusic(commands);
        if (arg is int floorId)
        {
            return new FloorEntry(floorId, music);
        }
        else if (arg is string collection)
        {
            return new FloorEntry(collection, music);
        }

        throw new InvalidArgException(arg);
    }

    private static IMusic GetFloorMusic(IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            if (command.Name != "music")
            {
                throw new Exception($"Invalid floor command \"{command.Name}\".");
            }

            var musicValue = MusicUtils.GetMusic(command.Value);
            if (musicValue.Type == MusicType.BattleBgm)
            {
                throw new Exception($"Floors cannot use Battle BGM.");
            }

            return musicValue;
        }

        throw new Exception("Invalid floor music.");
    }
}
