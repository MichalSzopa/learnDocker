using TodoApi.Database;
using TodoApi.Database.Models;
using Microsoft.EntityFrameworkCore;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext context;

    public ProjectRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateProject(Project project)
    {
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
    }

    public async Task<Project> GetById(int taskId)
    {
        return await context
                            .Projects
                            .Where(t => t.Id == taskId)
                            .Include(t => t.TodoTasks)
                            .FirstOrDefaultAsync();
    }

    public async Task<Project[]> GetProjectsForUser(int userId)
    {
        return await context
                            .Projects
                            .Where(t => t.UserId == userId)
                            .ToArrayAsync();
    }
}