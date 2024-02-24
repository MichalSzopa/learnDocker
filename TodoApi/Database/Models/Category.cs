namespace Database.Models;

public class Category
{
    public int Id { get; set; }

    public string Description { get; set; }

    public int Color { get; set; }

    public int UserId { get; set; }

    public bool IsPredefined { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<Project> Projects { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}
