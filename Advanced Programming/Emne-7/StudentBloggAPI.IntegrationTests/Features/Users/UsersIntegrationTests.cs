using System.Linq.Expressions;
using System.Net;
using Moq;
using Newtonsoft.Json;
using StudentBloggAPI.Features.Users;
using Xunit;

namespace StudentBloggAPI.IntegrationTests.Features.Users;

public class UsersIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public UsersIntegrationTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
    
    // .../api/v1/users/
    [Fact]
    public async Task GetUsers_When_NoSearchParameters_Then_ReturnsPagedUsers()
    {
        // Arrange
        List<User> users =
        [
            new()
            {
                FirstName = "Danica", LastName = "Kvilhaug", Email = "email@email.com",
                UserName = "Foxiecat", IsAdminUser = false, 
                HashedPassword = "$2a$11$C4c1rJmClZNy4868R89rvOiajmSjyqZbGiB/xPO4PNH0WKWDqY2tG",
                Id = Guid.Parse("709e0691-c250-41e7-9c02-74004396dd2e"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new()
            {
                FirstName = "Kari", LastName = "Normann", Email = "kari@email.com",
                UserName = "kari", HashedPassword = "jviprhipsvfnsjkfnjsd", IsAdminUser = false,
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            }
        ];
        
        
        _client.DefaultRequestHeaders.Add("Authorization", "Basic Rm94aWVjYXQ6Zm94aWVfY2F0");
        
        // Setup repository returns!
        // var usr = (await _userRepository.FindAsync(expr)).FirstOrDefault();
        _factory.MockUserRepository.Setup(x =>
                x.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync(new List<User> { users[0] });
        
        _factory.MockUserRepository.Setup(x =>
            x.GetPagedAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(users);
        
        
        
        // Act
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users");

        // Assert
        var data = JsonConvert.DeserializeObject<IEnumerable<UserResponse>>(await response.Content.ReadAsStringAsync());
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.Collection(data, u =>
        {
            Assert.Equal(u.FirstName, users[0].FirstName);
            Assert.Equal(u.LastName, users[0].LastName);
            Assert.Equal(u.Email, users[0].Email);
            Assert.Equal(u.UserName, users[0].UserName);
            Assert.Equal(u.Created, users[0].Created);
            Assert.Equal(u.Updated, users[0].Updated);
            Assert.Equal(u.Id, users[0].Id);
        },
        u =>
        {
            Assert.Equal(u.FirstName, users[1].FirstName);
            Assert.Equal(u.LastName, users[1].LastName);
            Assert.Equal(u.Email, users[1].Email);
            Assert.Equal(u.UserName, users[1].UserName);
            Assert.Equal(u.Created, users[1].Created);
            Assert.Equal(u.Updated, users[1].Updated);
            Assert.Equal(u.Id, users[1].Id);
        });
    }
}