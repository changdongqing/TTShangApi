using SqlSugar;

namespace TTShang.Domain.Entities;

/// <summary>
/// 实体基类
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键Id")]
    public long Id { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnDescription = "创建时间")]
    public DateTime CreatedTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 更新时间
    /// </summary>
    [SugarColumn(IsNullable = true, ColumnDescription = "更新时间")]
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    [SugarColumn(ColumnDescription = "是否删除")]
    public bool IsDeleted { get; set; } = false;
}
