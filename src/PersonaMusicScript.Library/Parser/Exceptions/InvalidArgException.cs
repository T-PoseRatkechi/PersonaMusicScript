namespace PersonaMusicScript.Library.Parser.Exceptions;

internal class InvalidArgException : Exception
{
    public InvalidArgException(object arg)
        : base($"Invalid command block argument type: {arg.GetType().Name}")
    {
    }
}
