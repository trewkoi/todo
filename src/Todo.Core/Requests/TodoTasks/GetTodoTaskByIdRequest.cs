namespace Todo.Core.Requests.TodoTasks;

public class GetTodoTaskByIdRequest : Request
{
    public long Id { get; set; }
}