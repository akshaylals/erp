namespace ERP3.Exceptions;

internal class EmptySearchException : Exception
{
    public EmptySearchException()
    {
    }

    public EmptySearchException(string message) : base(message)
    {
    }

    public EmptySearchException(string message, Exception inner) : base(message, inner)
    {
    }
}
