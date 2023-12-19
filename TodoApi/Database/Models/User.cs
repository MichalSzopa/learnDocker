namespace TodoApi.Database.Models;

public class User
{
    public int Id { get; set; } // Primary key, auto-incremented
    public string Login { get; set; } // Not null varchar
    public string Name { get; set; } // Not null varchar
    public string Password { get; set; } // Not null varchar
    public string Email { get; set; } // Not null varchar

    public virtual ICollection<Category> Categories { get; set; }

    public virtual ICollection<Project> Projects { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}