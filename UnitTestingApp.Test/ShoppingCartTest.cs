using Moq;
using UnitTestingApp.Functionality;
using Xunit;

namespace UnitTestingApp.Test;

public class ShoppingCartTest
{
    public readonly Mock<IDbService> _dbServiceMock = new();

    [Fact]
    public void AddProduct_Success()
    {
        // Given
        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);


        // When
        var product = new Product(1, "shoes", 150);
        var result = shoppingCart.AddProduct(product);


        // Assert
        Assert.True(result);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void AddProduct_Failure_DueToInvalidPayload()
    {
        // Given
        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);


        // When
        var result = shoppingCart.AddProduct(null);


        // Assert
        Assert.False(result);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
    }

    [Fact]
    public void RemoveProduct_Success()
    {
        // Given
        var shoppingCart = new ShoppingCart(_dbServiceMock.Object);


        // When
        var product = new Product(1, "shoes", 150);
        var result = shoppingCart.AddProduct(product);

        var deleteResult = shoppingCart.DeleteProduct(product.Id);

        // Assert
        Assert.True(deleteResult);
        _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
    }
}
