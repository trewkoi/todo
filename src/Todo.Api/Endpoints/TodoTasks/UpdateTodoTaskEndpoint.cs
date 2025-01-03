using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.TodoTasks;

public class UpdateTodoTaskEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:long}", HandleAsync)
            .WithName("TodoTasks: Update")
            .WithSummary("Updates a todoTask")
            .WithDescription("Uodates a todoTask")
            .Produces<Response<TodoTask?>>();

    private static async Task<IResult> HandleAsync(
        ITodoTaskHandler handler,
        UpdateTodoTaskRequest request,
        long id)
    {
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}