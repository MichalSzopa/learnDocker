using TodoApi.Database;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext context;
    public readonly ICategoryRepository CategoryRepository;
    public readonly ITaskRepository TaskRepository;

    public UnitOfWork(ApplicationDbContext context,
                      ICategoryRepository categoryRepository,
                      ITaskRepository taskRepository)
    {
        this.context = context;
        this.CategoryRepository = categoryRepository;
        this.TaskRepository = taskRepository;
    }

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }
}