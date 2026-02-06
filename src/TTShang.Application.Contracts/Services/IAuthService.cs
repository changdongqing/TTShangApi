using TTShang.Application.Contracts.Dtos;

namespace TTShang.Application.Contracts.Services;

/// <summary>
/// 认证服务接口
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// 登录
    /// </summary>
    Task<LoginOutput> LoginAsync(LoginInput input);

    /// <summary>
    /// 退出登录
    /// </summary>
    Task LogoutAsync();
}
