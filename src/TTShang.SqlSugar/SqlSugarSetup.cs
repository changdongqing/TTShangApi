using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using TTShang.Domain.Entities;
using TTShang.Domain.Shared.Consts;
using TTShang.Domain.Shared.Utils;

namespace TTShang.SqlSugar;

/// <summary>
/// SqlSugar 配置扩展
/// </summary>
public static class SqlSugarSetup
{
    /// <summary>
    /// 添加SqlSugar服务
    /// </summary>
    public static IServiceCollection AddSqlSugarSetup(this IServiceCollection services, string connectionString)
    {
        var db = new SqlSugarScope(new ConnectionConfig()
        {
            ConnectionString = connectionString,
            DbType = DbType.PostgreSQL,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute,
            ConfigureExternalServices = new ConfigureExternalServices
            {
                EntityService = (c, p) =>
                {
                    // 将C#的驼峰命名转换为下划线命名
                    p.DbColumnName = UtilMethods.ToUnderLine(p.DbColumnName);
                }
            }
        });

        // 初始化数据库表
        InitDatabase(db);

        services.AddSingleton<ISqlSugarClient>(db);

        return services;
    }

    /// <summary>
    /// 初始化数据库（创建表和种子数据）
    /// </summary>
    private static void InitDatabase(SqlSugarScope db)
    {
        // 创建数据库（如果不存在）
        db.DbMaintenance.CreateDatabase();

        // 创建表
        db.CodeFirst.InitTables(
            typeof(SysUser),
            typeof(SysRole),
            typeof(SysUserRole),
            typeof(SysMenu),
            typeof(SysRoleMenu)
        );

        // 初始化种子数据 - 默认管理员
        var adminUser = db.Queryable<SysUser>().First(u => u.UserName == AppConsts.DefaultAdminUserName);
        if (adminUser == null)
        {
            db.Insertable(new SysUser
            {
                UserName = AppConsts.DefaultAdminUserName,
                Password = PasswordHelper.HashPassword(AppConsts.DefaultAdminPassword),
                RealName = "管理员",
                NickName = "Admin",
            }).ExecuteCommand();
        }

        // 初始化种子数据 - 默认角色
        var adminRole = db.Queryable<SysRole>().First(r => r.Code == "admin");
        if (adminRole == null)
        {
            db.Insertable(new SysRole
            {
                Name = "管理员",
                Code = "admin",
                Sort = 1
            }).ExecuteCommand();
        }
    }
}
