using Microsoft.AspNetCore.Mvc;
using TimeAndCalendarManagement.APIs;
using TimeAndCalendarManagement.APIs.Common;
using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.APIs.Errors;

namespace TimeAndCalendarManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<UserDto>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserIdDto idDto)
    {
        try
        {
            await _service.DeleteUser(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<UserDto>>> Users([FromQuery()] UserFindMany filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<UserDto>> User([FromRoute()] UserIdDto idDto)
    {
        try
        {
            return await _service.User(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserIdDto idDto,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(idDto, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Users records to User
    /// </summary>
    [HttpPost("{Id}/users")]
    public async Task<ActionResult> ConnectUsers(
        [FromRoute()] UserIdDto idDto,
        [FromQuery()] UserIdDto[] usersId
    )
    {
        try
        {
            await _service.ConnectUsers(idDto, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Users records from User
    /// </summary>
    [HttpDelete("{Id}/users")]
    public async Task<ActionResult> DisconnectUsers(
        [FromRoute()] UserIdDto idDto,
        [FromBody()] UserIdDto[] usersId
    )
    {
        try
        {
            await _service.DisconnectUsers(idDto, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Users records for User
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<UserDto>>> FindUsers(
        [FromRoute()] UserIdDto idDto,
        [FromQuery()] UserFindMany filter
    )
    {
        try
        {
            return Ok(await _service.FindUsers(idDto, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a user record for User
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<UserDto>>> GetUser([FromRoute()] UserIdDto idDto)
    {
        var user = await _service.GetUser(idDto);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindMany filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Update multiple Users records for User
    /// </summary>
    [HttpPatch("{Id}/users")]
    public async Task<ActionResult> UpdateUsers(
        [FromRoute()] UserIdDto idDto,
        [FromBody()] UserIdDto[] usersId
    )
    {
        try
        {
            await _service.UpdateUsers(idDto, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
