using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.Infrastructure.Models;

namespace TimeAndCalendarManagement.APIs.Extensions;

public static class UsersExtensions
{
    public static UserDto ToDto(this User model)
    {
        return new UserDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Email = model.Email,
            Password = model.Password,
            Roles = model.Roles,
            Title = model.Title,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Description = model.Description,
            Users = model.Users?.Select(x => new UserIdDto { Id = x.Id }).ToList(),
            User = new UserIdDto { Id = model.UserId },
        };
    }

    public static User ToModel(this UserUpdateInput updateDto, UserIdDto idDto)
    {
        var user = new User
        {
            Id = idDto.Id,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Email = updateDto.Email,
            Title = updateDto.Title,
            StartTime = updateDto.StartTime,
            EndTime = updateDto.EndTime,
            Description = updateDto.Description
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }

        return user;
    }
}
