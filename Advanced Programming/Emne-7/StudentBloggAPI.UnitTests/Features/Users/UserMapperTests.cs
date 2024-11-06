using StudentBloggAPI.Features.Common.Interfaces;
using StudentBloggAPI.Features.Users;
using Xunit;

namespace StudentBloggAPI.UnitTests.Features.Users;

public class UserMapperTests
{
    private readonly IMapper<User, UserResponse> _userMapper = new UserMapper();

    [Fact]
    public void MapToDTO_When_UserModelIsValid_Should_Return_UserDTO()
    {
        // Arrange -> Klargjøre data som vi trenger til test
        User user = new()
        {
            Id = Guid.NewGuid(),
            Email = "email@email.com",
            FirstName = "Ola",
            LastName = "Normann",
            UserName = "ola_normann",
            IsAdminUser = false,
            Updated = new DateTime(2024, 10, 23, 9, 45, 00),
            Created = new DateTime(2024, 10, 23, 9, 45, 00),
            HashedPassword = "Perky-Creed-Luridness-Yo-yo-Fox9"
        };

        // Act
        UserResponse userResponse = _userMapper.MapToDTO(user);
        
        // Assert
        Assert.NotNull(userResponse);
        Assert.Equal(user.Id, userResponse.Id);
        Assert.Equal(user.Email, userResponse.Email);
        Assert.Equal(user.FirstName, userResponse.FirstName);
        Assert.Equal(user.LastName, userResponse.LastName);
        Assert.Equal(user.UserName, userResponse.UserName);
        Assert.Equal(user.Updated, userResponse.Updated);
        Assert.Equal(user.Created, userResponse.Created);
    }

    [Fact]
    public void MapToModel_When_UserDTOIsValid_Should_Return_UserModel()
    {
        // Arrange
        UserResponse userResponse = new()
        {
            Id = Guid.NewGuid(),
            Email = "email@email.com",
            FirstName = "Ola",
            LastName = "Normann",
            UserName = "ola_normann",
            Updated = new DateTime(2024, 10, 23, 9, 45, 00),
            Created = new DateTime(2024, 10, 23, 9, 45, 00)
        };

        // Act
        User userModel = _userMapper.MapToModel(userResponse);

        // Assert
        Assert.NotNull(userModel);
        Assert.Equal(userResponse.Id, userModel.Id);
        Assert.Equal(userResponse.Email, userModel.Email);
        Assert.Equal(userResponse.FirstName, userModel.FirstName);
        Assert.Equal(userResponse.LastName, userModel.LastName);
        Assert.Equal(userResponse.UserName, userModel.UserName);
        Assert.Equal(userResponse.Updated, userModel.Updated);
        Assert.Equal(userResponse.Created, userModel.Created);
    }
}