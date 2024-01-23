namespace TodoApi.Database.Models;

public class User
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
    
    public virtual ICollection<Category> Categories { get; set; }

    public virtual ICollection<Project> Projects { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}
