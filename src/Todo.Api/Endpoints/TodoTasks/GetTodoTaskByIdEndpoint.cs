using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.TodoTasks;

public class GetTodoTaskByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:long}", HandleAsync)
            .WithName("TodoTasks: GetById")
            .WithSummary("Get a todoTask")
            .WithDescription("Get a todoTask")
            .Produces<Response<TodoTask?>>();

    private static async Task<IResult> HandleAsync(
        ITodoTaskHandler handler,
        long id)
    {
        var request = new GetTodoTaskByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}