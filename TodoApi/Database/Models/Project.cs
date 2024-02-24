namespace Database.Models;

public class Project
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int? CategoryId  { get; set; }

    public int UserId { get; set; }
    
    public virtual Category Category { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}
