namespace TodoApi.Database.Models;

public class Category
{
    public int Id { get; set; } // Primary key, auto-incremented
    
    public string Description { get; set; } // Not null varchar
    
    public int Color; // Defined somewhere, todo for own user categories

    public int UserId; 

    public bool IsPredefined;

    public virtual User User { get; set; }
}