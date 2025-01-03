using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.TodoTasks;

public class DeleteTodoTaskEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:long}", HandleAsync)
            .WithName("TodoTasks: Delete")
            .WithSummary("Deletes a todoTask")
            .WithDescription("Deletes a todoTask")
            .Produces<Response<TodoTask?>>();

    private static async Task<IResult> HandleAsync(
        ITodoTaskHandler handler,
        long id)
    {
        var request = new DeleteTodoTaskRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}