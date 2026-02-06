using System.Security.Cryptography;
using System.Text;

namespace TTShang.Domain.Shared.Utils;

/// <summary>
/// 密码加密工具
/// </summary>
public static class PasswordHelper
{
    /// <summary>
    /// SHA256加密密码
    /// </summary>
    public static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var sb = new StringBuilder();
        foreach (var b in bytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

    /// <summary>
    /// 验证密码
    /// </summary>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var hash = HashPassword(password);
        return string.Equals(hash, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}
