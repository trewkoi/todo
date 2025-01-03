using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:long}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Deletes a category")
            .WithDescription("Deletes a category")
            .WithOrder(3)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new DeleteCategoryRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}