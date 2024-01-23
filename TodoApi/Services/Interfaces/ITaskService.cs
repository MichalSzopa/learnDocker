using TodoApi.Database.Models;

public interface ITaskService
{
    Task<TodoTask[]> GetTasksForUser(int userId);

    Task CreateNewTask(CreateTaskModel model, int userId);

    Task EditTask(EditTaskModel model, int userId);

    Task ChangeTaskStatus(ChangeTaskStatusModel model, int userId);

    Task<TodoTask> GetTaskById(int taskId);
}
