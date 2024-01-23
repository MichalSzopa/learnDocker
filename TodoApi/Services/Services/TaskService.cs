using TodoApi.Database.Models;

public class TaskService : ITaskService
{
    private readonly UnitOfWork unitOfWork;

    public TaskService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task ChangeTaskStatus(ChangeTaskStatusModel model, int userId)
    {
        var task = await unitOfWork.TaskRepository.GetById(model.TodoTaskId);
        task.Status = model.NewStatus;
        await unitOfWork.SaveChanges();
    }

    public async Task CreateNewTask(CreateTaskModel model, int userId)
    {
        var task = new TodoTask
        {
            UserId = userId,
            IsRecurring = model.IsRecurring,
            CreationDate = DateTime.Now,
            EventDate = model.EventDate,
            Time = model.Time,
            Title = model.Title,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Repetition = model.Repetition,
            Priority = model.Priority,
            Status = TaskStatus.Planned,
            Version = 1,
            ParentId = model.ParentId,
            ProjectId = model.ProjectId,
        };

        await unitOfWork.TaskRepository.CreateTask(task);
    }

    public async Task EditTask(EditTaskModel model, int userId)
    {
        var task = await unitOfWork.TaskRepository.GetById(model.Id);

        if (task.UserId != userId)
        {
            throw new Exception("No permission to task for user"); // TODO exception classes
        }

        task.Description = model.Description;
        task.IsRecurring = model.IsRecurring;
        task.EventDate = model.EventDate;
        task.Time = model.Time;
        task.Title = model.Title;
        task.Description = model.Description;
        task.Repetition = model.Repetition;
        task.Priority = model.Priority;
        await unitOfWork.SaveChanges();
    }

    public async Task<TodoTask> GetTaskById(int taskId)
    {
        return await unitOfWork.TaskRepository.GetById(taskId);
    }

    public async Task<TodoTask[]> GetTasksForUser(int userId)
    {
        return await unitOfWork.TaskRepository.GetTasksForUser(userId);
    }
}