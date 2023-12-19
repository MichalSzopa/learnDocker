namespace TodoApi.Database.Models;

public class TodoTask
{
    public int Id { get; set; } // Primary key, auto-incremented
    public int UserId { get; set; } // Foreign key to User entity, not null
    public bool IsRecurring { get; set; } // Indicates if the task is recurring, not null
    public DateTime CreationDate { get; set; } // Date and time of task creation, not null
    public DateTime EventDate { get; set; } // Date and time of task execution/start, not null
    public TimeSpan? Time { get; set; } // Optional time
    public string Title { get; set; } // Title of the task, not null
    public string Description { get; set; } // Optional description

    // Foreign key properties
    public int? CategoryId { get; set; } // Foreign key to Category entity
    public TaskRepetition? Repetition { get; set; } // Foreign key to Repetition entity
    public int RepetitionInterval { get; set; } // Optional repetition interval
    public TaskPriority? Priority { get; set; } // Foreign key to Priority entity
    public int? ParentId { get; set; } // Foreign key to Parent Task entity
    public int? ProjectId { get; set; } // Foreign key to Project entity

    // Virtual properties for Entity Framework relationships
    public virtual User User { get; set; } // Represents the User entity
    public virtual Category Category { get; set; } // Represents the Category entity
    public virtual TodoTask ParentTask { get; set; } // Represents the Parent Task entity
    public virtual Project Project { get; set; } // Represents the Project entity
}