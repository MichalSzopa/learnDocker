namespace TodoApi.Database.Models;

public class Category
{
    public int Id { get; set; } // Primary key, auto-incremented

    public string Description { get; set; } // Not null varchar

    public int Color { get; set; } // Defined somewhere, todo for own user categories

    public int UserId { get; set; }

    public bool IsPredefined { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<Project> Projects { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}