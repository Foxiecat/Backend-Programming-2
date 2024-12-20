using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentBloggAPI.Configurations;
using StudentBloggAPI.Data;
using StudentBloggAPI.Data.Health;
using StudentBloggAPI.Extensions;
using StudentBloggAPI.Features.Users;
using StudentBloggAPI.Features.Common.Interfaces;
using StudentBloggAPI.Features.Users.Interfaces;
using StudentBloggAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers();

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IMapper<User, UserResponse>, UserMapper>()
    .AddScoped<IMapper<User, UserRegistrationDTO>, UserRegistrationMapper>()
    .AddScoped<IUserRepository, UserRepository>();

builder.Services
    .AddValidatorsFromAssemblyContaining<Program>()
    .AddFluentValidationAutoValidation(config 
        => config.DisableDataAnnotationsValidation = true);

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("Database health check");

builder.Services
    .AddScoped<StudentBloggBasicAuthentication>()
    .Configure<BasicAuthenticationOptions>(builder.Configuration.GetSection("BasicAuthenticationOptions"));

// Add dbcontext
builder.Services.AddDbContext<StudentBloggDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))));
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddHttpContextAccessor()
    .AddEndpointsApiExplorer()
    .AddSwaggerBasicAuthentication();

// dette er ikke noe dere trenger å huske -> slå opp i serilog og se hvordan dette løses.
builder.Host.UseSerilog((context, configuration) => 
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseHealthChecks("/_health")
    .UseMiddleware<StudentBloggBasicAuthentication>()
    .UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program;