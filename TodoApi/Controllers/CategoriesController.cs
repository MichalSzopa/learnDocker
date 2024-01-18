using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodoApi.Database;
using TodoApi.Database.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{

    private readonly ICategoryService categoryService;
    private readonly IHeaderContextService headerContextService;

    public CategoriesController(ICategoryService categoryService, IHeaderContextService headerContextService)
    {
        this.categoryService = categoryService;
        this.headerContextService = headerContextService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get()
    {
        var userId = headerContextService.GetUserId();
        var categories = await categoryService.GetCategoriesForUser(userId);
        return Ok(categories);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<Category> GetById(int id)
    {
        return await categoryService.GetCategoryById(id);
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryModel model)
    {
        var userId = headerContextService.GetUserId();
        await categoryService.CreateNewCategoryForUser(model, userId);

        return Ok();
    }

    [Authorize]
    [HttpPost("edit")]
    public async Task<IActionResult> EditCategory(EditCategoryModel model)
    {
        await categoryService.EditCategory(model);

        return Ok();
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await categoryService.DeleteCategory(categoryId);

        return Ok();
    }
}
