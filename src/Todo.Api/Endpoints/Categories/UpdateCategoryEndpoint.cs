using Todo.Api.Common.Api;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:long}",HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Updates a category")
            .WithDescription("Updates a category")
            .WithOrder(2)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        UpdateCategoryRequest request,
        long id)
    {
        request.Id = id; 
        
        var result = await handler.UpdateAsync(request);
        
        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}