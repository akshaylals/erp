namespace ERP.Exceptions;

internal class EmptyCartException : Exception
{
    public EmptyCartException()
    {
    }

    public EmptyCartException(string message) : base(message)
    {
    }

    public EmptyCartException(string message, Exception inner) : base(message, inner)
    {
    }
}
