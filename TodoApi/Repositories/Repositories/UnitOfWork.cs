using TodoApi.Database;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext context;
    public readonly ICategoryRepository CategoryRepository;
    public readonly ITaskRepository TaskRepository;
    public readonly IProjectRepository ProjectRepository;

    public UnitOfWork(ApplicationDbContext context,
                      ICategoryRepository categoryRepository,
                      ITaskRepository taskRepository,
                      IProjectRepository projectRepository)
    {
        this.context = context;
        this.CategoryRepository = categoryRepository;
        this.TaskRepository = taskRepository;
        this.ProjectRepository = projectRepository;
    }

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }
}