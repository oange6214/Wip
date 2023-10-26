using UnitTestingApp.Functionality;
using Xunit;

namespace UnitTestingApp.Test;

public class UserManagementTesting
{
    [Fact]
    public void Add_CreateUser()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new("Jed", "Lin"));

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);  // Checking that the usermanagement list is not empty.
        Assert.Equal("Jed", savedUser.firstName);
        Assert.Equal("Lin", savedUser.lastName);
        Assert.False(savedUser.VerifiedEmail);
    }

    [Fact]
    public void Update_UpdateMobileNumber()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new("Jed", "Lin"));

        var firstUser = userManagement.AllUsers.First();
        firstUser.Phone = "+886989140123";

        userManagement.UpdatePhone(firstUser);

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.Equal("+886989140123", savedUser.Phone);
    }
}