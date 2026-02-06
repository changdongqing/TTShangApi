using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TTShang.Application.Contracts.Dtos;
using TTShang.Application.Contracts.Services;
using TTShang.Domain.Repositories;
using TTShang.Domain.Shared.Consts;
using TTShang.Domain.Shared.Enums;
using TTShang.Domain.Shared.Utils;

namespace TTShang.Application.Services;

/// <summary>
/// 认证服务（Furion动态API）
/// </summary>
[ApiDescriptionSettings("Default", Name = "Auth", Order = 100)]
public class AuthAppService : IDynamicApiController, IAuthService
{
    private readonly ISysUserRepository _userRepository;

    public AuthAppService(ISysUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// 登录
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<LoginOutput> LoginAsync(LoginInput input)
    {
        // 查找用户
        var user = await _userRepository.GetByUserNameAsync(input.UserName);
        if (user == null)
        {
            throw new Exception("用户名或密码错误");
        }

        // 验证密码
        if (!PasswordHelper.VerifyPassword(input.Password, user.Password))
        {
            throw new Exception("用户名或密码错误");
        }

        // 检查状态
        if (user.Status == StatusEnum.Disabled)
        {
            throw new Exception("用户已被禁用");
        }

        // 生成JWT Token
        var token = GenerateJwtToken(user.Id, user.UserName);

        // 更新最后登录时间
        user.LastLoginTime = DateTime.Now;
        await _userRepository.UpdateAsync(user);

        return new LoginOutput
        {
            UserId = user.Id,
            UserName = user.UserName,
            RealName = user.RealName,
            Avatar = user.Avatar,
            AccessToken = token
        };
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    [HttpPost]
    [Authorize]
    public Task LogoutAsync()
    {
        // 服务端无状态JWT，退出由客户端清除Token即可
        return Task.CompletedTask;
    }

    /// <summary>
    /// 生成JWT Token
    /// </summary>
    private static string GenerateJwtToken(long userId, string userName)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConsts.JwtSecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: AppConsts.JwtIssuer,
            audience: AppConsts.JwtAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(AppConsts.JwtExpireMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
