using System.ComponentModel.DataAnnotations;

namespace TTShang.Application.Contracts.Dtos;

/// <summary>
/// 登录请求DTO
/// </summary>
public class LoginInput
{
    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名不能为空")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不能为空")]
    public string Password { get; set; } = string.Empty;
}
