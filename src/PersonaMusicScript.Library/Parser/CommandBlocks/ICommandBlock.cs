using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal interface ICommandBlock
{
    CommandBlockType Type { get; }

    BaseEntry GetResult(object arg, IEnumerable<Command> commands);
}
