using PersonaMusicScript.Library.Models.Music.Entries;
using PersonaMusicScript.Library.Parser.Models;

namespace PersonaMusicScript.Library.Parser.CommandBlocks;

internal interface ICommandBlock
{
    CommandBlockType Type { get; }

    BaseEntry GetResult(object arg, IEnumerable<Command> commands);
}
