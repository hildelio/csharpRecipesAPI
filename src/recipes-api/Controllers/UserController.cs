using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{    
    public readonly IUserService _service;
    
    public UserController(IUserService service)
    {
        this._service = service;        
    }

    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {   
        try
        {
            User user = _service.GetUser(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }     
    }

    [HttpPost]
    public IActionResult Create([FromBody]User user)
    {
        if (user == null)
        {
            return NotFound();
        }
        _service.AddUser(user);
        return Created("", user);
    }

    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody]User user)
    {
        if (user == null)
        {
            return NotFound();
        }
        bool existUser = _service.UserExists(email);
        if (!existUser)
        {
            return NotFound("Usuário não existe");
        }
        try
        {
            _service.UpdateUser(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        bool existUser = _service.UserExists(email);
        if (!existUser)
        {
            return NotFound("Usuário não existe");
        }
        try
        {
            _service.DeleteUser(email);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 
}