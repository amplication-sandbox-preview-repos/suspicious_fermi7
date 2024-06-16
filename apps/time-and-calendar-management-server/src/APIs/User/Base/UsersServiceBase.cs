using Microsoft.EntityFrameworkCore;
using TimeAndCalendarManagement.APIs;
using TimeAndCalendarManagement.APIs.Common;
using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.APIs.Errors;
using TimeAndCalendarManagement.APIs.Extensions;
using TimeAndCalendarManagement.Infrastructure;
using TimeAndCalendarManagement.Infrastructure.Models;

namespace TimeAndCalendarManagement.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly TimeAndCalendarManagementDbContext _context;

    public UsersServiceBase(TimeAndCalendarManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<UserDto> CreateUser(UserCreateInput createDto)
    {
        var user = new User
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Username = createDto.Username,
            Email = createDto.Email,
            Password = createDto.Password,
            Roles = createDto.Roles,
            Title = createDto.Title,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime,
            Description = createDto.Description
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id;
        }
        if (createDto.Users != null)
        {
            user.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<User>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserIdDto idDto)
    {
        var user = await _context.Users.FindAsync(idDto.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<UserDto>> Users(UserFindMany findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<UserDto> User(UserIdDto idDto)
    {
        var users = await this.Users(
            new UserFindMany { Where = new UserWhereInput { Id = idDto.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserIdDto idDto, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(idDto);

        if (updateDto.Users != null)
        {
            user.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Users records to User
    /// </summary>
    public async Task ConnectUsers(UserIdDto idDto, UserIdDto[] usersId)
    {
        var user = await _context
            .Users.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(t => usersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (users.Count == 0)
        {
            throw new NotFoundException();
        }

        var usersToConnect = users.Except(user.Users);

        foreach (var user in usersToConnect)
        {
            user.Users.Add(user);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Users records from User
    /// </summary>
    public async Task DisconnectUsers(UserIdDto idDto, UserIdDto[] usersId)
    {
        var user = await _context
            .Users.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(t => usersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var user in users)
        {
            user.Users?.Remove(user);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Users records for User
    /// </summary>
    public async Task<List<UserDto>> FindUsers(UserIdDto idDto, UserFindMany userFindMany)
    {
        var users = await _context
            .Users.Where(m => m.Users.Any(x => x.Id == idDto.Id))
            .ApplyWhere(userFindMany.Where)
            .ApplySkip(userFindMany.Skip)
            .ApplyTake(userFindMany.Take)
            .ApplyOrderBy(userFindMany.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a user record for User
    /// </summary>
    public async Task<UserDto> GetUser(UserIdDto idDto)
    {
        var user = await _context
            .Users.Where(user => user.Id == idDto.Id)
            .Include(user => user.Users)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException();
        }
        return user.Users.ToDto();
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public async Task<MetadataDto> UsersMeta(UserFindMany findManyArgs)
    {
        var count = await _context.Users.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Users records for User
    /// </summary>
    public async Task UpdateUsers(UserIdDto idDto, UserIdDto[] usersId)
    {
        var user = await _context
            .Users.Include(t => t.Users)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var users = await _context
            .Users.Where(a => usersId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (users.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Users = users;
        await _context.SaveChangesAsync();
    }
}
