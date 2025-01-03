namespace Todo.Core.Requests.TodoTasks;

public class DeleteTodoTaskRequest : Request
{
    public long Id { get; set; }
}