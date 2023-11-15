
namespace Checkout;

public sealed class NonFoodStockList : IStockList
{
    public IEnumerable<Product> GetProducts()
    {
        throw new NotImplementedException();
    }
}