using SqlSugar;
using TTShang.Domain.Shared.Enums;

namespace TTShang.Domain.Entities;

/// <summary>
/// 系统用户表
/// </summary>
[SugarTable("sys_user", TableDescription = "系统用户表")]
public class SysUser : EntityBase
{
    /// <summary>
    /// 用户名
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = false, ColumnDescription = "用户名")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码（加密存储）
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = false, ColumnDescription = "密码")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 真实姓名
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = true, ColumnDescription = "真实姓名")]
    public string? RealName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = true, ColumnDescription = "昵称")]
    public string? NickName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [SugarColumn(Length = 512, IsNullable = true, ColumnDescription = "头像")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [SugarColumn(ColumnDescription = "性别")]
    public GenderEnum Gender { get; set; } = GenderEnum.Unknown;

    /// <summary>
    /// 邮箱
    /// </summary>
    [SugarColumn(Length = 128, IsNullable = true, ColumnDescription = "邮箱")]
    public string? Email { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [SugarColumn(Length = 20, IsNullable = true, ColumnDescription = "手机号")]
    public string? Phone { get; set; }

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

    /// <summary>
    /// 最后登录时间
    /// </summary>
    [SugarColumn(IsNullable = true, ColumnDescription = "最后登录时间")]
    public DateTime? LastLoginTime { get; set; }
}
