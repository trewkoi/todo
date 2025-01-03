

using Microsoft.AspNetCore.Mvc;
using Todo.Api.Common.Api;
using Todo.Core;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.TodoTasks;

public class GetAllTodoTasksEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("TodoTasks: GetAll")
            .WithSummary("Get all todoTask")
            .WithDescription("Get all todoTask")
            .Produces<PagedResponse<List<TodoTask>?>>();

    private static async Task<IResult> HandleAsync(
        ITodoTaskHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllTodoTasksRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}