namespace Checkout;

public sealed class Shop
{
    private readonly IStockList _stockList;
    private readonly ILog _log;

    public Shop(IStockList stockList)
    {
        _stockList = stockList;
        _log = new ConsoleLog();
    }

    public Shop(IStockList stockList, ILog log)
    {
        _stockList = stockList;
        _log = log;
    }

    public IEnumerable<Product> GetProducts()
    {
        try
        {
            return _stockList.GetProducts();
        }
        catch (TimeoutException timeoutEx)
        {
            // write exception details to some log
            _log.Write(timeoutEx.Message);

            return new List<Product>();
        }
        catch (SystemNotAvailableException)
        {
            // send email to supplier telling them their db is dead
            // STDIN = standard input stream provided by the OS
            // STDOUT = standard output stream provided by the operating system

            throw new Exception("everything is dead");
        }
    }
}