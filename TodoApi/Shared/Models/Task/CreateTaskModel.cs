public class CreateTaskModel
{
    public bool IsRecurring { get; set; }

    public DateTime EventDate { get; set; }

    public string? Time { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int? CategoryId { get; set; }

    public TaskRepetition? Repetition { get; set; }

    public TaskPriority? Priority { get; set; }

    public int? ParentId { get; set; }

    public int? ProjectId { get; set; }
}