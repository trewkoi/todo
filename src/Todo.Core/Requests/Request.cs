namespace Todo.Core.Requests;

public abstract class Request
{
    public string UserId { get; set; } = string.Empty;
}