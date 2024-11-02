﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController // C# 12 Primary constructor feature
{
    [AllowAnonymous]
    [HttpGet]
    public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return Ok(users);
    }

    [Authorize]
    [HttpGet("{id:int}")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        var user = await context.Users.FindAsync(id);
        
        if (user == null) return NotFound();

        return user;
    }


}
