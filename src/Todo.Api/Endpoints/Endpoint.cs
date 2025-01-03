using Todo.Api.Common.Api;
using Todo.Api.Endpoints.Categories;
using Todo.Api.Endpoints.TodoTasks;
using Todo.Core.Requests.TodoTasks;

namespace Todo.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");
        
        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<GetAllCategoriesEndpoint>();

        endpoints.MapGroup("v1/todotasks")
            .WithTags("Tasks")
            .MapEndpoint<CreateTodoTaskEndpoint>()
            .MapEndpoint<UpdateTodoTaskEndpoint>()
            .MapEndpoint<DeleteTodoTaskEndpoint>()
            .MapEndpoint<GetTodoTaskByIdEndpoint>()
            .MapEndpoint<GetAllTodoTasksEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}