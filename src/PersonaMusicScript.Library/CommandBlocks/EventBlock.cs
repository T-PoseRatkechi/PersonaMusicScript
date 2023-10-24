using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public class EventBlock : ICommandBlock
{
    public CommandBlockType Type { get; } = CommandBlockType.Event;

    public void Process(MusicSource source, CommandBlock block)
    {
        var eventFile = block.Arg as string
            ?? throw new ArgumentException($"Invalid event block arg \"{block.Arg}\".");

        foreach (var command in block.Commands)
        {
            var frame = ushort.Parse(command.Name.Split('_')[1]);
            var musicValue = CommandUtils.GetMusic(command.Value);

            if (source.Events.TryGetValue(eventFile, out var eventFrame))
            {
                eventFrame.FrameBgms.Add(new() { StartFrame = frame, Music = musicValue });
            }
            else
            {
                var newEvent = new EventFrame(eventFile);
                newEvent.FrameBgms.Add(new() { StartFrame = frame, Music = musicValue });
                source.Events.Add(eventFile, newEvent);
            }
        }
    }
}
