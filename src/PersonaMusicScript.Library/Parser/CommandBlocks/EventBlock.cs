using PersonaMusicScript.Library.Parser.Exceptions;
using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal class EventBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Event;

    public BaseEntry GetResult(object arg, IEnumerable<Command> commands)
    {
        EventEntry? result;

        if (arg is FrameTable eventFrame)
        {
            result = new(eventFrame);
        }
        else if (arg is string)
        {
            throw new NotImplementedException("Event files not supported.");
        }
        else
        {
            throw new InvalidArgException(arg);
        }

        foreach (var command in commands)
        {
            var frameId = ushort.Parse(command.Name.Split('_')[1]);
            IMusic? musicValue;

            if (command.Value is string stringValue
                && stringValue == "disable")
            {
                musicValue = null;
            }
            else
            {
                musicValue = MusicUtils.GetMusic(command.Value);
            }

            eventFrame.Frames[frameId] = musicValue;
        }

        return result;
    }
}
