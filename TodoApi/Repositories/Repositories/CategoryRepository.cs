using Microsoft.EntityFrameworkCore;
using TodoApi.Database;
using TodoApi.Database.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext context;

    public CategoryRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateCategory(Category category)
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
}