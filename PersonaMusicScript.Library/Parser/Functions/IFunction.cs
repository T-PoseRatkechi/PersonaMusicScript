using Antlr4.Runtime.Misc;

namespace PersonaMusicScript.Library.Parser.Functions;

internal interface IFunction<TReturn>
{
    string Name { get; }

    TReturn Invoke([NotNull] SourceParser.FunctionContext context);
}
