namespace Checkout;

public sealed class FileLog : ILog
{
    public void Write(string message)
    {
        // write message to some kind of flat file
        throw new NotImplementedException();
    }
}