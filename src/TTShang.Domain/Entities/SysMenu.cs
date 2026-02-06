using SqlSugar;

namespace TTShang.Domain.Entities;

/// <summary>
/// 系统菜单表
/// </summary>
[SugarTable("sys_menu", TableDescription = "系统菜单表")]
public class SysMenu : EntityBase
{
    /// <summary>
    /// 父级Id
    /// </summary>
    [SugarColumn(ColumnDescription = "父级Id")]
    public long ParentId { get; set; } = 0;

    /// <summary>
    /// 菜单名称
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = false, ColumnDescription = "菜单名称")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 菜单类型（1目录 2菜单 3按钮）
    /// </summary>
    [SugarColumn(ColumnDescription = "菜单类型")]
    public int Type { get; set; } = 1;

    /// <summary>
    /// 路由地址
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true, ColumnDescription = "路由地址")]
    public string? Path { get; set; }

    /// <summary>
    /// 组件路径
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true, ColumnDescription = "组件路径")]
    public string? Component { get; set; }

    /// <summary>
    /// 权限标识
    /// </summary>
    [SugarColumn(Length = 128, IsNullable = true, ColumnDescription = "权限标识")]
    public string? Permission { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    [SugarColumn(Length = 128, IsNullable = true, ColumnDescription = "图标")]
    public string? Icon { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Sort { get; set; } = 0;

    /// <summary>
    /// 是否可见
    /// </summary>
    [SugarColumn(ColumnDescription = "是否可见")]
    public bool Visible { get; set; } = true;
}
