namespace Todo.Core.Models;

public class Comment
{
    public long Id { get; set; }
    public long TaskId { get; set; }
    public long AuthorId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}