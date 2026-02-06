using System.Net.Http.Json;
using Microsoft.JSInterop;
using TTShang.Application.Contracts.Dtos;

namespace TTShang.Blazor.Client.Services;

/// <summary>
/// 客户端认证服务实现（通过HTTP调用后端API）
/// </summary>
public class AuthClientService : IAuthClientService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private LoginOutput? _currentUser;

    private const string TokenKey = "auth_token";
    private const string UserKey = "auth_user";

    public AuthClientService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<LoginOutput?> LoginAsync(LoginInput input)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/auth/login", input);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception(errorContent.Length > 0 ? errorContent : "登录失败");
        }

        var result = await response.Content.ReadFromJsonAsync<LoginOutput>();
        if (result != null)
        {
            _currentUser = result;
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, result.AccessToken);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UserKey, System.Text.Json.JsonSerializer.Serialize(result));
        }
        return result;
    }

    public async Task LogoutAsync()
    {
        _currentUser = null;
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", UserKey);
    }

    public async Task<LoginOutput?> GetCurrentUserAsync()
    {
        if (_currentUser != null) return _currentUser;

        try
        {
            var userJson = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", UserKey);
            if (!string.IsNullOrEmpty(userJson))
            {
                _currentUser = System.Text.Json.JsonSerializer.Deserialize<LoginOutput>(userJson);
            }
        }
        catch
        {
            // SSR模式下无法访问localStorage
        }

        return _currentUser;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        try
        {
            var token = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", TokenKey);
            return !string.IsNullOrEmpty(token);
        }
        catch
        {
            return false;
        }
    }
}
