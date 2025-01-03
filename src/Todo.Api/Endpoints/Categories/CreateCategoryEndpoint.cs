using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Creates a new category")
            .WithDescription("Creates a new category")
            .WithOrder(1)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result.Data)
            : Results.BadRequest(result);
    }
}