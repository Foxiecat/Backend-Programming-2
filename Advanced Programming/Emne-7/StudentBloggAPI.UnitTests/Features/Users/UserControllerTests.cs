using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StudentBloggAPI.Features.Users;
using StudentBloggAPI.Features.Users.Interfaces;
using Xunit;

namespace StudentBloggAPI.UnitTests.Features.Users;

public class UserControllerTests
{
    private readonly UsersController _userController;
    private readonly Mock<ILogger<UsersController>> _mockLogger = new();
    private readonly Mock<IUserService> _mockUserService = new();

    public UserControllerTests()
    {
        _userController = new UsersController(_mockLogger.Object, _mockUserService.Object);
    }

    [Fact]
    public async Task GetUsersAsync_When_DefaultPageSize_And_OneUserExist_ShouldReturnOneUser()
    {
        // Arrange
        List<UserResponse> listOfDTOS =
        [
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ola",
                LastName = "Normann",
                UserName = "ola_normann",
                Email = "ola_normann@gmail.com",
                Updated = DateTime.UtcNow,
                Created = DateTime.UtcNow
            }
        ];
        
        // _userService.GetPagedAsync(pageNr,pageSize);
        _mockUserService.Setup(
            x=> x.GetPagedAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(listOfDTOS);

        // Act
        var result = await _userController.GetUsersAsync(new UserSearchParams());

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<UserResponse>>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var userDTOS = Assert.IsType<List<UserResponse>>(returnValue.Value);
        
        UserResponse? userDTO = userDTOS.FirstOrDefault();
        Assert.NotNull(userDTO);
        Assert.Equal(userDTO.UserName, listOfDTOS[0].UserName);
    }
}