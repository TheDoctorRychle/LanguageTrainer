using LanguageTrainer.Data;
using LanguageTrainer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageTrainer.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController(ApplicationDbContext context) : ControllerBase 
{
    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = context.Categories.ToList();
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult AddCategory([FromBody] Category category)
    {
        if(category is null) return BadRequest();
        
        context.Categories.Add(category);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = context.Categories.Find(id);
        if(category is null) return NotFound();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = context.Categories.Find(id);
        if(category is null) return NotFound();
        context.Categories.Remove(category);
        context.SaveChanges();
        return NoContent();
    }
}