using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController // C# 12 Primary constructor feature
{
    [HttpGet]
    public async Task <ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();

        // var userToReturn = mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(users);
    }

    [HttpGet("{id:int}")] // api/users/3
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await userRepository.GetMemberByIdAsync(id);
        
        if (user == null) return NotFound();

        return user;
    }

    [HttpGet("{userName}")] // api/users/marva
    public async Task<ActionResult<MemberDto>> GetUserByName(string userName)
    {
        var user = await userRepository.GetMemberAsync(userName);
        
        if (user == null) return NotFound();

        return user;

    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (username is null) return BadRequest("No username found in token");

        var user = await userRepository.GetUserByUserNameAsync(username);

        if (user == null) return BadRequest("Could not find user");

        mapper.Map(memberUpdateDto, user);

        if (await userRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update the user");
    }


}
