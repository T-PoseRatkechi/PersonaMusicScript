using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public class EventBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Event;

    public void Process(MusicSource source, CommandBlock block)
    {
        if (block.Arg is EventFrame eventFrame)
        {
        }
        else if (block.Arg is string)
        {
            throw new NotImplementedException("Event files not supported.");
        }
        else
        {
            throw new ArgumentException($"Invalid event block arg \"{block.Arg}\".");
        }

        foreach (var command in block.Commands)
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
                musicValue = CommandUtils.GetMusic(command.Value);
            }

            if (source.Events.TryGetValue(eventFrame.Ids, out var existingFrame))
            {
                existingFrame.FrameMusic[frameId] = musicValue;
            }
            else
            {
                eventFrame.FrameMusic[frameId] = musicValue;
                source.AddEventFrame(eventFrame);
            }
        }
    }
}
