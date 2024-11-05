using System.Net;
using BlazorLoginApp.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        string? backendIdUrl = Environment.GetEnvironmentVariable("OIDC_ID_ADDRESS_FOR_SERVER");
        string? clientIdUrl = Environment.GetEnvironmentVariable("OIDC_CLIENT_ID_ADDRESS_FOR_USERS");

        options.Configuration = new OpenIdConnectConfiguration
        {
            Issuer = backendIdUrl,
            AuthorizationEndpoint = backendIdUrl + $"{clientIdUrl}/protocol/openid-connect/auth",
            TokenEndpoint = backendIdUrl + $"{clientIdUrl}/protocol/openid-connect/token",
            JwksUri = $"{backendIdUrl}/protocol/openid-connect/certs",
            JsonWebKeySet = FetchJwks($"{backendIdUrl}/protocol/openid-connect/certs"),
            EndSessionEndpoint = $"{clientIdUrl}/protocol/openid-connect/logout"
        };

        Console.WriteLine($"Jwks: {options.Configuration.JsonWebKeySet}");

        foreach (SecurityKey? key in options.Configuration.JsonWebKeySet.GetSigningKeys())
        {
            options.Configuration.SigningKeys.Add(key);

            Console.WriteLine($"Signing Key: {key.KeyId}");
        }
        
        options.ClientId = Environment.GetEnvironmentVariable("OIDC_CLIENT_ID");
        
        options.TokenValidationParameters.ValidIssuers = [clientIdUrl, backendIdUrl];
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        
        // Https
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.MapInboundClaims = true;
        
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
    }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/logout", async (HttpContext httpContext) =>
{
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await httpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
});

app.Run();
return;


JsonWebKeySet FetchJwks(string url)
{
    HttpClient httpClient = new();
    
    var result = httpClient.GetAsync(url).Result;
    if (!result.IsSuccessStatusCode || result.Content is null)
    {
        throw new Exception(
            $"Failed to fetch JWKS: {url}. Status code {result.StatusCode}.");
    }
    
    var jwks = result.Content.ReadAsStringAsync().Result;
    return new JsonWebKeySet(jwks);
}