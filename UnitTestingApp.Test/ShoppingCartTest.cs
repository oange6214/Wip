using UnitTestingApp.Functionality;
using Xunit;

namespace UnitTestingApp.Test;

public class DbServiceMock : IDbService
{
    public bool ProcessResult { get; set; }

    public Product ProductBeingProcessed { get; set; }

    public int ProductIdBeingProcessed { get; set; }

    public bool RemoveItemFromShoppingCart(int? prodId)
    {
        if (prodId == null)
        {
            return false;
        }

        ProductIdBeingProcessed = Convert.ToInt32(prodId);
        return ProcessResult;
    }

    public bool SaveItemToShoppingCart(Product? prod)
    {
        if (prod == null)
        {
            return false;
        }

        ProductBeingProcessed = prod;
        return ProcessResult;
    }
}

public class ShoppingCartTest
{
    [Fact]
    public void AddProduct_Success()
    {
        // Given
        var dbMock = new DbServiceMock();
        dbMock.ProcessResult = true;

        var shoppingCart = new ShoppingCart(dbMock);


        // When
        var product = new Product(1, "shoes", 150);
        var result = shoppingCart.AddProduct(product);


        // Assert
        Assert.True(result);
        Assert.Equal(result, dbMock.ProcessResult);
        Assert.Equal("shoes", dbMock.ProductBeingProcessed.Name);
    }
}
