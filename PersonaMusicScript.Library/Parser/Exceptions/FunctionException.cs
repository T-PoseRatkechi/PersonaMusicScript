using Antlr4.Runtime;

namespace PersonaMusicScript.Library.Parser.Exceptions;

internal class FunctionException : ParsingException
{
    public FunctionException(string name, int expected, int actual, ParserRuleContext context)
        : base($"Function \"{name}\" expects {expected} arguments. Actual: {actual}", context)
    {
    }
}
