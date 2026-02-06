using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using TTShangApi.Models.DTOs;

namespace TTShangApi.Tests;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_WithValidData_ReturnsOkWithToken()
    {
        var request = new RegisterRequest
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
        Assert.NotNull(result);
        Assert.NotEmpty(result.Token);
        Assert.Equal("testuser", result.Username);
        Assert.Equal("test@example.com", result.Email);
    }

    [Fact]
    public async Task Register_WithDuplicateUsername_ReturnsBadRequest()
    {
        
        var request = new RegisterRequest
        {
            Username = "duplicateuser",
            Email = "first@example.com",
            Password = "password123"
        };

        await _client.PostAsJsonAsync("/api/auth/register", request);

        var request2 = new RegisterRequest
        {
            Username = "duplicateuser",
            Email = "second@example.com",
            Password = "password123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/register", request2);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsOkWithToken()
    {
        
        var registerRequest = new RegisterRequest
        {
            Username = "loginuser",
            Email = "login@example.com",
            Password = "password123"
        };

        await _client.PostAsJsonAsync("/api/auth/register", registerRequest);

        var loginRequest = new LoginRequest
        {
            Username = "loginuser",
            Password = "password123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
        Assert.NotNull(result);
        Assert.NotEmpty(result.Token);
        Assert.Equal("loginuser", result.Username);
    }

    [Fact]
    public async Task Login_WithInvalidPassword_ReturnsUnauthorized()
    {
        
        var registerRequest = new RegisterRequest
        {
            Username = "wrongpwuser",
            Email = "wrongpw@example.com",
            Password = "password123"
        };

        await _client.PostAsJsonAsync("/api/auth/register", registerRequest);

        var loginRequest = new LoginRequest
        {
            Username = "wrongpwuser",
            Password = "wrongpassword"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithNonexistentUser_ReturnsUnauthorized()
    {
        var loginRequest = new LoginRequest
        {
            Username = "nonexistent",
            Password = "password123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithInvalidEmail_ReturnsBadRequest()
    {
        var request = new RegisterRequest
        {
            Username = "bademail",
            Email = "not-an-email",
            Password = "password123"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithShortPassword_ReturnsBadRequest()
    {
        var request = new RegisterRequest
        {
            Username = "shortpw",
            Email = "short@example.com",
            Password = "12345"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
