using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task CreateTask(TodoTask task)
    {
        await context.TodoTasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async Task<TodoTask> GetById(int taskId)
    {
        return await context
            .TodoTasks
            .Where(t => t.Id == taskId)
            .Include(t => t.ChildTasks)
            .FirstOrDefaultAsync();
    }

    public async Task Add(TodoTask entity)
    {
        await context.TodoTasks.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<TodoTask[]> GetTasksForProject(int projectId)
    {
        return await context
            .TodoTasks
            .Where(t => t.ProjectId == projectId && t.ParentId == null)
            .Include(t => t.ChildTasks)
            .ToArrayAsync();
    }

    public async Task<TodoTask[]> GetTasksForUser(int userId)
    {
        return await context
            .TodoTasks
            .Where(t => t.UserId == userId && t.ParentId == null)
            .Include(t => t.ChildTasks)
            .ToArrayAsync();
    }

    public async Task<IEnumerable<TodoTask>> GetTasksToNotifyForUsers()
    {
        var dateTimeDelay = DateTime.Now + TimeSpan.FromMinutes(15);

        return await context
            .TodoTasks
            .Where(t => t.EventDate >= dateTimeDelay && t.NotificationEmailSent == false)
            .Include(t => t.User)
            .ToListAsync();
    }
}