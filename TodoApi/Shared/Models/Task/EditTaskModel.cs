public class EditTaskModel
{
    public int Id { get; set; }

    public bool IsRecurring { get; set; }

    public DateTime EventDate { get; set; }

    public TimeSpan? Time { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public TaskRepetition? Repetition { get; set; }
    
    public TaskPriority? Priority { get; set; }
}
