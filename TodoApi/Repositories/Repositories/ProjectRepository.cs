using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repositories;

public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
{
    public async Task CreateProject(Project project) // TODO remove
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

    public async Task Add(Project entity)
    {
        await context.Projects.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Project[]> GetProjectsForUser(int userId)
    {
        return await context
            .Projects
            .Where(t => t.UserId == userId)
            .ToArrayAsync();
    }
}