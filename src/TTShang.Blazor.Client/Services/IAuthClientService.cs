using TTShang.Application.Contracts.Dtos;

namespace TTShang.Blazor.Client.Services;

/// <summary>
/// 客户端认证服务接口
/// </summary>
public interface IAuthClientService
{
    /// <summary>
    /// 登录
    /// </summary>
    Task<LoginOutput?> LoginAsync(LoginInput input);

    /// <summary>
    /// 退出登录
    /// </summary>
    Task LogoutAsync();

    /// <summary>
    /// 获取当前登录信息
    /// </summary>
    Task<LoginOutput?> GetCurrentUserAsync();

    /// <summary>
    /// 是否已登录
    /// </summary>
    Task<bool> IsAuthenticatedAsync();
}
