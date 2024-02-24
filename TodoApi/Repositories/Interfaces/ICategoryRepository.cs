using Database.Models;

namespace Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task CreateCategory(Category category);

    Task DeleteCategory(int id);

    Task<Category> GetById(int id);

    Task<Category[]> GetCategoriesForUser(int userId);
}