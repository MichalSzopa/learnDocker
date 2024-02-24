using Database;
using Database.Models;
using Repositories.Interfaces;

namespace Repositories.Repositories;

public class UnitOfWork(
    ApplicationDbContext context,
    ICategoryRepository categoryRepository,
    ITaskRepository taskRepository,
    IProjectRepository projectRepository)
    : IUnitOfWork
{
    public ICategoryRepository CategoryRepository => categoryRepository;
    
    public IProjectRepository ProjectRepository => projectRepository;

    public ITaskRepository TaskRepository => taskRepository;

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }
}