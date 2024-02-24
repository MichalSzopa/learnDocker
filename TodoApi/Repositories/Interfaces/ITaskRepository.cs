using Database.Models;

namespace Repositories.Interfaces;

public interface ITaskRepository : IBaseRepository<TodoTask>
{
    Task CreateTask(TodoTask task);

    Task<TodoTask> GetById(int taskId);

    Task<TodoTask[]> GetTasksForUser(int userId);

    Task<TodoTask[]> GetTasksForProject(int projectId);

    Task<IEnumerable<TodoTask>> GetTasksToNotifyForUsers();
}