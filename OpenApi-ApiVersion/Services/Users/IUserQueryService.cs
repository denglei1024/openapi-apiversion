using OpenApi_ApiVersion.Domain.Users;

namespace OpenApi_ApiVersion.Services.Users;

public interface IUserQueryService
{
    IReadOnlyList<User> GetUsers();
}

