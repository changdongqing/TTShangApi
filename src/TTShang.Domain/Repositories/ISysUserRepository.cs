using TTShang.Domain.Entities;

namespace TTShang.Domain.Repositories;

/// <summary>
/// 用户仓储接口
/// </summary>
public interface ISysUserRepository
{
    /// <summary>
    /// 根据用户名获取用户
    /// </summary>
    Task<SysUser?> GetByUserNameAsync(string userName);

    /// <summary>
    /// 根据Id获取用户
    /// </summary>
    Task<SysUser?> GetByIdAsync(long id);

    /// <summary>
    /// 新增用户
    /// </summary>
    Task<bool> InsertAsync(SysUser user);

    /// <summary>
    /// 更新用户
    /// </summary>
    Task<bool> UpdateAsync(SysUser user);

    /// <summary>
    /// 检查用户名是否存在
    /// </summary>
    Task<bool> ExistsUserNameAsync(string userName);
}
