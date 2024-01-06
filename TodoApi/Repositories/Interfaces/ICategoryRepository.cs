using TodoApi.Database.Models;

public interface ICategoryRepository
{
    Task CreateCategory(Category category);

    Task DeleteCategory(int id);

    Task<Category> GetById(int id);

    Task<Category[]> GetCategoriesForUser(int userId);
}