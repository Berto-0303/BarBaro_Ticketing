using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingAPI.Data;
using TicketingAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Category
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _context.Category.ToListAsync();
        return Ok(categories);
    }

    // GET: api/Category/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _context.Category.FindAsync(id);
        if (category == null)
            return NotFound("Category not found");

        return Ok(category);
    }

    // POST: api/Category
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        if (category == null)
            return BadRequest("Invalid category data");

        _context.Category.Add(category);
        await _context.SaveChangesAsync();
        return Ok("Category created successfully");
    }

    // PUT: api/Category/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
    {
        var existingCategory = await _context.Category.FindAsync(id);
        if (existingCategory == null)
            return NotFound("Category not found");

        existingCategory.CategoryName = category.CategoryName;

        _context.Category.Update(existingCategory);
        await _context.SaveChangesAsync();
        return Ok("Category updated successfully");
    }

    // DELETE: api/Category/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Category.FindAsync(id);
        if (category == null)
            return NotFound("Category not found");

        _context.Category.Remove(category);
        await _context.SaveChangesAsync();
        return Ok("Category deleted successfully");
    }
}
