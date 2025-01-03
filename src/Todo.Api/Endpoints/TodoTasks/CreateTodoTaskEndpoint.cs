using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.TodoTasks;

public class CreateTodoTaskEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("TodoTasks: Create")
            .WithSummary("Creates a todoTask")
            .WithDescription("Creates a todoTask")
            .Produces<Response<TodoTask?>>();

    private static async Task<IResult> HandleAsync(
        ITodoTaskHandler handler,
        CreateTodoTaskRequest request)
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result.Data)
            : Results.BadRequest(result);
    }
}