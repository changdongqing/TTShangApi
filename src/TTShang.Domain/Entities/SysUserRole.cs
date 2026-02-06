using SqlSugar;

namespace TTShang.Domain.Entities;

/// <summary>
/// 系统用户角色关联表
/// </summary>
[SugarTable("sys_user_role", TableDescription = "系统用户角色关联表")]
public class SysUserRole : EntityBase
{
    /// <summary>
    /// 用户Id
    /// </summary>
    [SugarColumn(ColumnDescription = "用户Id")]
    public long UserId { get; set; }

    /// <summary>
    /// 角色Id
    /// </summary>
    [SugarColumn(ColumnDescription = "角色Id")]
    public long RoleId { get; set; }
}
