using Todo.Core.Enums;

namespace Todo.Core.Models;

public class TodoTask
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DueDate { get; set; }

    public bool Completed { get; set; }

    public ETaskPriority Priority { get; set; } = ETaskPriority.Low;
    public ETaskStatus Status { get; set; } = ETaskStatus.Pending;
    
    public long AssignedTo { get; set; }
    
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public List<Comment> Comments { get; set; } = [];
}