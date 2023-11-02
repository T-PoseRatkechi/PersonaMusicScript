using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

internal class GlobalBgmBlock : ICommandBlock
{
    private readonly MusicResources resources;

    public GlobalBgmBlock(MusicResources resources)
    {
        this.resources = resources;
    }

    public CommandBlockType Type { get; } = CommandBlockType.Global_Bgm;

    public void Process(MusicSource source, CommandBlock block)
    {
        foreach (var command in block.Commands)
        {
            if (command.Name != "music")
            {
                throw new Exception($"Unknown global bgm commmand: {command.Name}");
            }

            var musicValue = CommandUtils.GetMusic(command.Value);

            if (block.Arg is int songId)
            {
                source.Global.Add(songId, musicValue);
            }
            else if (block.Arg is string songName)
            {
                var song = this.resources.Songs[songName];
                source.Global.Add(song, musicValue);
            }

            throw new Exception($"Invalid global bgm block arg \"{block.Arg}\".");
        }
    }
}
