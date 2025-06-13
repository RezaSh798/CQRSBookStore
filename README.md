# 📚 CQRS Book Store API

A modern .NET 9 implementation of CQRS pattern with advanced features including caching, validation.

## 🌟 Features

- **Clean CQRS Implementation** - Strict separation of commands and queries
- **Fluent Validation** - Comprehensive input validation
- **Smart Caching** - With automatic invalidation on data changes
- **Redis Support** - Optional distributed caching
- **Swagger Documentation** - Interactive API documentation

## 🚀 Quick Start

### Prerequisites
- .NET 9 SDK
- SQL Server 2019+
- (Optional) Redis for distributed caching

### Clone project
```bash
git clone https://github.com/your-repo/cqrs-bookstore.git
cd cqrs-bookstore
```
### Configuration
Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BookStore;User Id=sa;Password=your_password;TrustServerCertificate=true;",
    "Redis": "localhost:6379"
  }
}
```

### Restore packages
`dotnet restore`

### Run the application
`dotnet run`

### 📜 License
Distributed under the MIT License. See LICENSE for more information.