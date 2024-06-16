using TimeAndCalendarManagement.APIs.Common;
using TimeAndCalendarManagement.APIs.Dtos;

namespace TimeAndCalendarManagement.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<UserDto> CreateUser(UserCreateInput userDto);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserIdDto idDto);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<UserDto>> Users(UserFindMany findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<UserDto> User(UserIdDto idDto);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserIdDto idDto, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Users records to User
    /// </summary>
    public Task ConnectUsers(UserIdDto idDto, UserIdDto[] usersId);

    /// <summary>
    /// Disconnect multiple Users records from User
    /// </summary>
    public Task DisconnectUsers(UserIdDto idDto, UserIdDto[] usersId);

    /// <summary>
    /// Find multiple Users records for User
    /// </summary>
    public Task<List<UserDto>> FindUsers(UserIdDto idDto, UserFindMany UserFindMany);

    /// <summary>
    /// Get a user record for User
    /// </summary>
    public Task<UserDto> GetUser(UserIdDto idDto);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindMany findManyArgs);

    /// <summary>
    /// Update multiple Users records for User
    /// </summary>
    public Task UpdateUsers(UserIdDto idDto, UserIdDto[] usersId);
}
