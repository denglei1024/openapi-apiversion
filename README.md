# OpenAPI API Versioning + Scalar + MVC Controllers

这个示例把原来的 Minimal API 重构成了更接近生产项目的 MVC Controller 结构，同时保留：

- URL Segment API Versioning
- OpenAPI 多版本文档（`v1` / `v2`）
- Scalar 文档聚合界面
- `ProblemDetails` 异常输出

## 目录结构

```text
OpenApi-ApiVersion/
├─ OpenApi-ApiVersion/
│  ├─ Controllers/
│  │  ├─ V1/UsersController.cs
│  │  └─ V2/UsersController.cs
│  ├─ Contracts/
│  │  ├─ V1/Users/UserListItemResponse.cs
│  │  └─ V2/Users/UserListItemResponse.cs
│  ├─ Domain/Users/User.cs
│  ├─ Extensions/
│  │  ├─ ServiceCollectionExtensions.cs
│  │  └─ WebApplicationExtensions.cs
│  ├─ Services/Users/
│  │  ├─ IUserQueryService.cs
│  │  └─ InMemoryUserQueryService.cs
│  └─ Program.cs
└─ OpenApi-ApiVersion.sln
```

## 运行

```powershell
dotnet build "~./OpenApi-ApiVersion.sln"
dotnet run --project "~./OpenApi-ApiVersion/OpenApi-ApiVersion.csproj"
```

## 访问地址

```text
GET /api/v1/users
GET /api/v2/users
GET /openapi/v1.json
GET /openapi/v2.json
GET /scalar
GET /scalar/v1
GET /scalar/v2
```


