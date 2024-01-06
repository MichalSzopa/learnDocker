using TodoApi.Database.Models;

public class CategoryService : ICategoryService
{
    private readonly UnitOfWork unitOfWork;

    public CategoryService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task CreateNewCategoryForUser(CreateCategoryModel model, int userId)
    {
        var category = new Category 
        {
            Description = model.Description,
            Color = model.Color,
            UserId = userId,
            IsPredefined = false
        };

        await unitOfWork.CategoryRepository.CreateCategory(category);
    }

    public async Task DeleteCategory(int categoryId)
    {
        await unitOfWork.CategoryRepository.DeleteCategory(categoryId);
    }

    public async Task EditCategory(EditCategoryModel category)
    {
        var editedCategory = await unitOfWork.CategoryRepository.GetById(category.Id);

        editedCategory.Description = category.Description;
        editedCategory.Color = category.Color;

        await unitOfWork.SaveChanges();
    }

    public async Task<Category[]> GetCategoriesForUser(int userId)
    {
        return await unitOfWork.CategoryRepository.GetCategoriesForUser(userId);
    }

    public async Task<Category> GetCategoryById(int categoryId)
    {
        return await unitOfWork.CategoryRepository.GetById(categoryId);
    }
}