using OpenApi_ApiVersion.Domain.Users;

namespace OpenApi_ApiVersion.Services.Users;

public sealed class InMemoryUserQueryService : IUserQueryService
{
    private static readonly IReadOnlyList<User> Users =
    [
        new(1, "Alice", "alice@example.com"),
        new(2, "Bob", null)
    ];

    public IReadOnlyList<User> GetUsers() => Users;
}

