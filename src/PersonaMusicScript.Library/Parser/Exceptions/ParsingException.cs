using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace PersonaMusicScript.Library.Parser.Exceptions;

internal class ParsingException : Exception
{
    public ParsingException()
    {
    }

    public ParsingException(string message, ParserRuleContext context)
        : base($"{message}\nLine {context.Start.Line}: {GetOriginalText(context)}")
    {
    }

    public ParsingException(string message, ParserRuleContext context, Exception innerException)
        : base($"{message}\nLine {context.Start.Line}: {GetOriginalText(context)}\n{innerException.Message}", innerException)
    {
    }

    private static string GetOriginalText(ParserRuleContext context)
    {
        var interval = new Interval(context.Start.StartIndex, context.Stop.StopIndex);
        return context.Start.InputStream.GetText(interval);
    }
}
