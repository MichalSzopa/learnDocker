namespace Database.Models;

public class TodoTask
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public bool IsRecurring { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime EventDate { get; set; }

    public TimeSpan? Time { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public int? CategoryId { get; set; }
    
    public TaskRepetition? Repetition { get; set; }
    
    public TaskPriority? Priority { get; set; }

    public TaskStatus Status { get; set; }

    public int Version { get; set; }
    
    public int? ParentId { get; set; }
    
    public int? ProjectId { get; set; }

    public bool NotificationEmailSent { get; set; }
    
    public virtual User User { get; set; }
    
    public virtual Category Category { get; set; }
    
    public virtual TodoTask ParentTask { get; set; }

    public virtual Project Project { get; set; }
    
    public virtual ICollection<TodoTask> ChildTasks { get; set; }
}
