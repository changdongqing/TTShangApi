# TTShang 管理系统

基于 **Furion** + **MudBlazor** + **SqlSugar** 的 DDD 架构应用框架

## 技术栈

- **.NET 8** - 运行时框架
- **Furion** - 方法即服务（动态API控制器）
- **MudBlazor** - Material Design Blazor 组件库
- **SqlSugar** - ORM 框架（对接 PostgreSQL）
- **Blazor WebApp** - Auto 模式（Server + WebAssembly）

## 项目结构

```
src/
├── TTShang.Domain.Shared        # 共享层：枚举、常量、工具类
├── TTShang.Domain               # 领域层：实体、仓储接口
├── TTShang.Application.Contracts # 应用契约层：DTO、服务接口
├── TTShang.Application          # 应用层：服务实现（Furion动态API）
├── TTShang.SqlSugar             # 基础设施层：SqlSugar ORM、仓储实现
├── TTShang.Blazor.Client        # 客户端：MudBlazor UI 组件
└── TTShang.Blazor               # 主机：Blazor WebApp 入口
```

## 数据库表

| 表名 | 说明 |
|------|------|
| sys_user | 系统用户表 |
| sys_role | 系统角色表 |
| sys_user_role | 用户角色关联表 |
| sys_menu | 系统菜单表 |
| sys_role_menu | 角色菜单关联表 |

## 快速开始

### 前置条件

- .NET 8 SDK
- PostgreSQL 数据库

### 配置

修改 `src/TTShang.Blazor/appsettings.json` 中的数据库连接字符串和 JWT 密钥：

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=ttshang;Username=postgres;Password=your_password"
  },
  "JwtSettings": {
    "SecretKey": "your_secure_secret_key_at_least_32_chars"
  }
}
```

### 构建运行

```bash
dotnet build TTShang.sln
dotnet run --project src/TTShang.Blazor
```

应用将在 `https://localhost:5001` 启动。

### 默认账户

- 用户名：`admin`
- 密码：`123456`

## 已实现功能

- ✅ 登录 / 退出（JWT 认证）
- ✅ 用户管理数据库表（实体定义）
- ✅ MudBlazor Material Design UI
- ✅ Blazor Auto 模式（SSR + WASM）
- ✅ Furion 动态 API
- ✅ SqlSugar ORM + PostgreSQL