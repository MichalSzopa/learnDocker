using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task CreateCategory(Category category) // TODO remove
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }


    public async Task<Category> GetById(int id)
    {
        return await context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task DeleteCategory(int id)
    {
        await context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }

    public async Task<Category[]> GetCategoriesForUser(int userId)
    {
        return await context.Categories.Where(c => c.IsPredefined == true || c.UserId == userId).ToArrayAsync();
    }

    public async Task Add(Category entity)
    {
        await context.Categories.AddAsync(entity);
        await context.SaveChangesAsync();
    }
}