namespace Checkout;

public sealed class ConsoleLog : ILog
{
    public void Write(string message)
    {
        Console.Write(message);
    }
}