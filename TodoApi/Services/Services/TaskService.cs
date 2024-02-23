using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using TodoApi.Database.Models;
using TodoApi.Shared.Models;

public class TaskService : ITaskService
{
    private readonly UnitOfWork unitOfWork;
    private readonly SmtpValuesModel smtpValues;

    public TaskService(UnitOfWork unitOfWork, IOptions<SmtpValuesModel> smtpValues)
    {
        this.unitOfWork = unitOfWork;
        this.smtpValues = smtpValues.Value;
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
            Time = TimeSpan.Parse(model.Time),
            Title = model.Title,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Repetition = model.Repetition,
            Priority = model.Priority,
            Status = TaskStatus.Planned,
            Version = 1,
            ParentId = model.ParentId,
            ProjectId = model.ProjectId,
            NotificationEmailSent = false,
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

    public async Task SendNotifications()
    {
        var tasks = await unitOfWork.TaskRepository.GetTasksToNotifyForUsers();
        if (tasks == null)
        {
            return;
        }
        sendEmailsForTasks(tasks);
        foreach (var task in tasks)
        {
            task.NotificationEmailSent = true;
        }
        await unitOfWork.SaveChanges();
    }

    private void sendEmailsForTasks(IEnumerable<TodoTask> tasks)
    {
        var groups = tasks.GroupBy(t => t.UserId);

        foreach (var group in groups)
        {
            var subject = "Unfinished tasks notification";
            var message = "information about tasks"; // TODO prepare a pretty message
            var receiverEmail = group.FirstOrDefault().User.Email;

            sendEmail(receiverEmail, subject, message);
        }
    }

    private void sendEmail(string receiverEmail, string subject, string message)
    {
        using var client = new SmtpClient(smtpValues.ServerAddress, smtpValues.ServerPort)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(smtpValues.SenderEmail, smtpValues.AppPassword)
        };

        client.Send(new MailMessage(from: smtpValues.SenderEmail,
                                                    to: receiverEmail,
                                                    subject,
                                                    message));
    }
}