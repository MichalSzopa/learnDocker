namespace TodoApi.Database.Models;

public class Project
{
    public int Id { get; set; } // Project Id
    
    public string Title { get; set; } // Project title
    
    public string Description { get; set; } // Project description
    
    public int CategoryId  { get; set; }

    public int UserId { get; set; }
    
    public virtual Category Category { get; set; } // Project category

    public virtual User User { get; set; }

    public virtual ICollection<TodoTask> TodoTasks { get; set; }
}