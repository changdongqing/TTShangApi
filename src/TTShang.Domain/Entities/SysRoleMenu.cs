using SqlSugar;

namespace TTShang.Domain.Entities;

/// <summary>
/// 系统角色菜单关联表
/// </summary>
[SugarTable("sys_role_menu", TableDescription = "系统角色菜单关联表")]
public class SysRoleMenu : EntityBase
{
    /// <summary>
    /// 角色Id
    /// </summary>
    [SugarColumn(ColumnDescription = "角色Id")]
    public long RoleId { get; set; }

    /// <summary>
    /// 菜单Id
    /// </summary>
    [SugarColumn(ColumnDescription = "菜单Id")]
    public long MenuId { get; set; }
}
