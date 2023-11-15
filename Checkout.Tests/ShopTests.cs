using Moq;
using NUnit.Framework;

namespace Checkout.Tests;

public class Tests
{
    [Test]
    public void CheckShopGetProductsReturnsProducts()
    {
        var fakeProducts = new[]
            {
                new Product { Name = "Product 1", Price = 10m },
                new Product { Name = "Product 2", Price = 20m },
                new Product { Name = "Product 3", Price = 30m }
            };

        var mockStockList = new Mock<IStockList>();
        mockStockList
            .Setup(stockList => stockList.GetProducts())
            .Returns(fakeProducts);

        var shop = new Shop(mockStockList.Object);

        var products = shop.GetProducts();

        Assert.That(products, Is.EqualTo(fakeProducts));
    }

    [Test]
    public void CheckShopGetProductsReturnsEmptyProductListWhenTimeoutExceptionThrown()
    {
        var mockStockList = new Mock<IStockList>();
        mockStockList
            .Setup(stockList => stockList.GetProducts())
            .Throws(new TimeoutException("Couldn't talk to the supplier database."));

        var shop = new Shop(mockStockList.Object);
        var products = shop.GetProducts();

        Assert.That(products, Is.Not.Null);
        Assert.That(products.Count(), Is.EqualTo(0));
    }

    [Test]
    public void CheckShopGetProductsReturnsEmptyProductListWhenSystemUnavailableExceptionThrown()
    {
        var mockStockList = new Mock<IStockList>();
        mockStockList
            .Setup(stockList => stockList.GetProducts())
            .Throws(new SystemNotAvailableException("Supplier database is down or dead."));

        var shop = new Shop(mockStockList.Object);
        var products = shop.GetProducts();

        Assert.That(products, Is.Not.Null);
        Assert.That(products.Count(), Is.EqualTo(0));
    }
}