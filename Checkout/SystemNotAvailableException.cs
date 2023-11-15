namespace Checkout;

public sealed class SystemNotAvailableException : Exception
{
    public SystemNotAvailableException(string message) : base(message)
    {

    }
}