using StudentBloggAPI.Features.Common.Interfaces;
using StudentBloggAPI.Features.Users;
using Xunit;

namespace StudentBloggAPI.UnitTests.Features.Users;

public class UserMapperTests
{
    private readonly IMapper<User, UserDTO> _userMapper = new UserMapper();

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
        UserDTO userDTO = _userMapper.MapToDTO(user);
        
        // Assert
        Assert.NotNull(userDTO);
        Assert.Equal(user.Id, userDTO.Id);
        Assert.Equal(user.Email, userDTO.Email);
        Assert.Equal(user.FirstName, userDTO.FirstName);
        Assert.Equal(user.LastName, userDTO.LastName);
        Assert.Equal(user.UserName, userDTO.UserName);
        Assert.Equal(user.Updated, userDTO.Updated);
        Assert.Equal(user.Created, userDTO.Created);
    }

    [Fact]
    public void MapToModel_When_UserDTOIsValid_Should_Return_UserModel()
    {
        // Arrange
        UserDTO userDTO = new()
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
        User userModel = _userMapper.MapToModel(userDTO);

        // Assert
        Assert.NotNull(userModel);
        Assert.Equal(userDTO.Id, userModel.Id);
        Assert.Equal(userDTO.Email, userModel.Email);
        Assert.Equal(userDTO.FirstName, userModel.FirstName);
        Assert.Equal(userDTO.LastName, userModel.LastName);
        Assert.Equal(userDTO.UserName, userModel.UserName);
        Assert.Equal(userDTO.Updated, userModel.Updated);
        Assert.Equal(userDTO.Created, userModel.Created);
    }
}