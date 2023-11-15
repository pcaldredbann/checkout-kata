namespace Checkout;

public interface IStockList
{
    IEnumerable<Product> GetProducts();
}
