using System.Data.Common;
using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:long}", HandleAsync)
        .WithName("Categories: GetById")
        .WithSummary("Gets a category by Id")
        .WithDescription("Gets a category by Id")
        .WithOrder(4)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id
        };
        
        var result = await handler.GetByIdAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}