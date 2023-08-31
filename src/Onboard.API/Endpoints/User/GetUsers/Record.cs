namespace Onboard.API.Endpoints.User.GetUsers;

public record UserRecord(Guid Id, string Name, string Username, string Email, int RoleId);
