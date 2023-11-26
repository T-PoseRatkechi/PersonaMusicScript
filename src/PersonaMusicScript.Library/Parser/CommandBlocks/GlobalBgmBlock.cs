using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal class GlobalBgmBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Global_Bgm;

    public BaseEntry GetResult(object arg, IEnumerable<Command> commands)
    {
        var music = GetGlobalMusic(commands);
        if (arg is int bgmId)
        {
            return new GlobalBgmEntry(bgmId, music);
        }
        else if (arg is string songName)
        {
            return new GlobalBgmEntry(songName, music);
        }

        throw new InvalidArgException(arg);
    }

    private static IMusic GetGlobalMusic(IEnumerable<Command> commands)
    {
        foreach (var command in commands)
        {
            if (command.Name != "music")
            {
                throw new Exception($"Unknown Global BGM commmand: {command.Name}");
            }

            var musicValue = MusicUtils.GetMusic(command.Value);
            return musicValue;
        }

        throw new Exception("Invalid global BGM music.");
    }
}
