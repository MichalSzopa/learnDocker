using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TodoApi.Database;
using TodoApi.Database.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{

    public CategoriesController()
    {
    }

    [Authorize]
    [HttpGet]
    public async Task<Category[]> Get()
    {
        using var context = new ApplicationDbContext();
        return await context.Categories.ToArrayAsync();
    }
}
