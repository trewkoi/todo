using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Core.Handlers;

public interface ITodoTaskHandler
{
    Task<Response<TodoTask?>> CreateAsync(CreateTodoTaskRequest request);
    Task<Response<TodoTask?>> UpdateAsync(UpdateTodoTaskRequest request);
    Task<Response<TodoTask?>> DeleteAsync(DeleteTodoTaskRequest request);
    Task<Response<TodoTask?>> GetByIdAsync(GetTodoTaskByIdRequest request);
    Task<PagedResponse<List<TodoTask>?>> GetAllAsync(GetAllTodoTasksRequest request);
}