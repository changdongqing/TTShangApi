namespace TTShang.Domain.Shared.Consts;

/// <summary>
/// 应用常量
/// </summary>
public static class AppConsts
{
    /// <summary>
    /// 默认管理员用户名
    /// </summary>
    public const string DefaultAdminUserName = "admin";

    /// <summary>
    /// 默认管理员密码
    /// </summary>
    public const string DefaultAdminPassword = "123456";

    /// <summary>
    /// JWT Token 密钥
    /// </summary>
    public const string JwtSecretKey = "TTShang_SecretKey_2024_MinLength32Chars!";

    /// <summary>
    /// JWT Token 发行者
    /// </summary>
    public const string JwtIssuer = "TTShang";

    /// <summary>
    /// JWT Token 受众
    /// </summary>
    public const string JwtAudience = "TTShang.Client";

    /// <summary>
    /// JWT Token 过期时间（分钟）
    /// </summary>
    public const int JwtExpireMinutes = 120;
}
