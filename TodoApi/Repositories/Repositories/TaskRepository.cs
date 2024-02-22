using TodoApi.Database;
using TodoApi.Database.Models;
using Microsoft.EntityFrameworkCore;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext context;

    public TaskRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

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
                            .Where(t => t.EventDate >= dateTimeDelay)
                            .Include(t => t.User)
                            .ToListAsync();

    }
}
