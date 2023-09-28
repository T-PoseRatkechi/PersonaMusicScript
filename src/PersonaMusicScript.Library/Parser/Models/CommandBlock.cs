namespace PersonaMusicScript.Library.Parser.Models;

public record CommandBlock(CommandBlockType Type, object Arg, Command[] Commands);
