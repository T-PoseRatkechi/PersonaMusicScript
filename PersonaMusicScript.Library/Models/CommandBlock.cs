namespace PersonaMusicScript.Library.Models;

public record CommandBlock(CommandBlockType Type, object Arg, Command[] commands);
