using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.CommandBlocks;

public interface ICommandBlock
{
    CommandBlockType Type { get; }

    void Process(MusicSource source, CommandBlock block);
}
