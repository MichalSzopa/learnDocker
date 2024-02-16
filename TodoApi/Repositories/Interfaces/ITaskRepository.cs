using TodoApi.Database.Models;

public interface ITaskRepository
{
    Task CreateTask(TodoTask task);

    Task<TodoTask> GetById(int taskId);

    Task<TodoTask[]> GetTasksForUser(int userId);

    Task<TodoTask[]> GetTasksForProject(int projectId);

    Task<IEnumerable<TodoTask>> GetTasksToNotifyForUsers();
}
