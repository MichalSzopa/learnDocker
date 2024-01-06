
using TodoApi.Database.Models;

public interface ICategoryService
{
    Task<Category[]> GetCategoriesForUser(int userId);

    Task CreateNewCategoryForUser(CreateCategoryModel model, int userId);

    Task DeleteCategory(int categoryId);

    Task EditCategory(EditCategoryModel category);

    Task<Category> GetCategoryById(int categoryId);
}