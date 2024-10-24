﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;


[ApiController]
[Route("[controller]")] // / api/users
public class UsersController(DataContext context) : ControllerBase // C# 12 Primary constructor feature
{
    [HttpGet]
    public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return Ok(users);
    }

    [HttpGet("{id:int}")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        var user = await context.Users.FindAsync(id);
        
        if (user == null) return NotFound();

        return user;
    }

}
