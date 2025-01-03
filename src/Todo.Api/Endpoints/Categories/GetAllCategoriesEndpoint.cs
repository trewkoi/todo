using Microsoft.AspNetCore.Mvc;
using Todo.Api.Common.Api;
using Todo.Core;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Categories: GetAll")
            .WithSummary("Gets all categories")
            .WithDescription("Gets all categories")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
        )
    {
        var request = new GetAllCategoriesRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);
        
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}