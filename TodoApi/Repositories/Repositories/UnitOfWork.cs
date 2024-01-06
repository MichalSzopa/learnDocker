using TodoApi.Database;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext context;
    public readonly ICategoryRepository CategoryRepository;

    public UnitOfWork(ApplicationDbContext context,
                      ICategoryRepository categoryRepository)
    {
        this.context = context;
        this.CategoryRepository = categoryRepository;
    }

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }
}