using SqlSugar;
using TTShang.Domain.Shared.Enums;

namespace TTShang.Domain.Entities;

/// <summary>
/// 系统角色表
/// </summary>
[SugarTable("sys_role", TableDescription = "系统角色表")]
public class SysRole : EntityBase
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = false, ColumnDescription = "角色名称")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 角色编码
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = false, ColumnDescription = "角色编码")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Sort { get; set; } = 0;

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; } = StatusEnum.Enabled;

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(Length = 512, IsNullable = true, ColumnDescription = "备注")]
    public string? Remark { get; set; }
}
