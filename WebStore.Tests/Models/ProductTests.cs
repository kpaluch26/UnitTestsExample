using WebStore.Models;

namespace WebStore.Tests.Models;

public class ProductTests
{
    private Product _product;

    public ProductTests()
    {
        _product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            Manufacturer = "Test Manufacturer",
            Price = 99.99,
            Quantity = 500
        };
    }

    [Fact]
    public void ApplyDiscount_ChangesPriceCorrectly()
    {
        // Arrange
        int discount = 16;
        double newCorrectPrice = _product.Price - Math.Round(_product.Price * discount / 100, 2);

        // Act
        _product.ApplyPercentageDiscount(discount);

        // Assert
        Assert.Equal(newCorrectPrice, _product.Price);
    }

    [Fact]
    public void PlaceBulkOrder_ReduceQuantityCorrectly()
    {
        // Arrange
        int orderQuantity = _product.Quantity * 25 / 100;
        int newCorrectQuantity = _product.Quantity - orderQuantity;

        // Act
        bool result = _product.PlaceBulkOrder(orderQuantity);

        // Assert
        Assert.True(result);
        Assert.Equal(newCorrectQuantity, _product.Quantity);
    }

    [Fact]
    public void PlaceBulkOrder_FailsWhenQuantityIsTooLarge()
    {
        // Arrange
        int orderQuantity = _product.Quantity + 2;
        int newCorrectQuantity = _product.Quantity;

        // Act
        bool result = _product.PlaceBulkOrder(orderQuantity);

        // Assert
        Assert.False(result);
        Assert.Equal(newCorrectQuantity, _product.Quantity);
    }
}
