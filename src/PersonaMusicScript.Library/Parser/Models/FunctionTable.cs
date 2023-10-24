using PersonaMusicScript.Library.Parser.Functions;

namespace PersonaMusicScript.Library.Parser.Models;

internal class FunctionTable : Dictionary<string, Func<SourceParser.FunctionContext, object?>>
{
    public void Add<T>(IFunction<T> function)
    {
        this.Add(function.Name, (context) => function.Invoke(context));
    }
}
