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
[Route("recipe")]
public class RecipesController : ControllerBase
{    
    public readonly IRecipeService _service;
    
    public RecipesController(IRecipeService service)
    {
        this._service = service;        
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<Recipe> recipes = _service.GetRecipes();
        return Ok(recipes);
    }

    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {                
        Recipe recipe = _service.GetRecipe(name);
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Recipe recipe)
    {
        if (recipe == null)
        {
            BadRequest("A receita não pode ser nula.");
        }
        _service.AddRecipe(recipe);
        return Created("", recipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody]Recipe recipe)
    {
        if (recipe == null)
        {
            BadRequest("A receita não pode ser nula.");
        }
        bool existRecipe = _service.RecipeExists(name);
        if (!existRecipe)
        {
            BadRequest($" A receita {name} não existe");
        }
        try
        {
        _service.UpdateRecipe(recipe);
        return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    // 5 - Sua aplicação deve ter o endpoint DEL /recipe
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        bool existRecipe = _service.RecipeExists(name);
        if (!existRecipe)
        {
            BadRequest($" A receita {name} não existe");
        }
        try
        {
            _service.DeleteRecipe(name);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }    
}
