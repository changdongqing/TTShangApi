using SqlSugar;
using TTShang.Domain.Entities;
using TTShang.Domain.Repositories;

namespace TTShang.SqlSugar.Repositories;

/// <summary>
/// 用户仓储实现
/// </summary>
public class SysUserRepository : ISysUserRepository
{
    private readonly ISqlSugarClient _db;

    public SysUserRepository(ISqlSugarClient db)
    {
        _db = db;
    }

    public async Task<SysUser?> GetByUserNameAsync(string userName)
    {
        return await _db.Queryable<SysUser>()
            .Where(u => u.UserName == userName && !u.IsDeleted)
            .FirstAsync();
    }

    public async Task<SysUser?> GetByIdAsync(long id)
    {
        return await _db.Queryable<SysUser>()
            .Where(u => u.Id == id && !u.IsDeleted)
            .FirstAsync();
    }

    public async Task<bool> InsertAsync(SysUser user)
    {
        return await _db.Insertable(user).ExecuteCommandAsync() > 0;
    }

    public async Task<bool> UpdateAsync(SysUser user)
    {
        user.UpdatedTime = DateTime.Now;
        return await _db.Updateable(user).ExecuteCommandAsync() > 0;
    }

    public async Task<bool> ExistsUserNameAsync(string userName)
    {
        return await _db.Queryable<SysUser>()
            .Where(u => u.UserName == userName && !u.IsDeleted)
            .AnyAsync();
    }
}
