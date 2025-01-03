using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Core.Enums;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Requests.TodoTasks;
using Todo.Core.Responses;

namespace Todo.Api.Handlers;

public class TodoTaskHandler(AppDbContext context) : ITodoTaskHandler
{
    public async Task<Response<TodoTask?>> CreateAsync(CreateTodoTaskRequest request)
    {
        try
        {
            var todoTask = new TodoTask
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DueDate = request.DueDate,
                Priority = request.Priority,
                Status = request.Status,
                AssignedTo = request.AssignedTo,
                CategoryId = request.CategoryId
            };

            await context.TodoTasks.AddAsync(todoTask);
            await context.SaveChangesAsync();

            return new Response<TodoTask?>(todoTask, 201, "Tarefa criada com sucesso!");
        }
        catch
        {
            return new Response<TodoTask?>(null, 500, "Não foi possível criar a tarefa");
        }
    }

    public async Task<Response<TodoTask?>> UpdateAsync(UpdateTodoTaskRequest request)
    {
        try
        {
            var todoTask = await context.TodoTasks.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todoTask is null)
                return new Response<TodoTask?>(null, 404, "Categoria não encontrada");

            todoTask.Title = request.Title;
            todoTask.Description = request.Description;
            todoTask.UpdatedAt = DateTime.Now;
            todoTask.DueDate = request.DueDate;
            todoTask.Priority = request.Priority;
            todoTask.Status = request.Status;
            todoTask.AssignedTo = request.AssignedTo;
            todoTask.CategoryId = request.CategoryId;

            await context.SaveChangesAsync();

            return new Response<TodoTask?>(todoTask, message: "Tarefa atualizada com sucesso!");
        }
        catch
        {
            return new Response<TodoTask?>(null, 500, "Não foi possível atualizar a tarefa");
        }
    }

    public async Task<Response<TodoTask?>> DeleteAsync(DeleteTodoTaskRequest request)
    {
        try
        {
            var todoTask = await context.TodoTasks.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todoTask is null)
                return new Response<TodoTask?>(null, 404, "Tarefa não encontrada");

            context.TodoTasks.Remove(todoTask);
            await context.SaveChangesAsync();

            return new Response<TodoTask?>(todoTask, message: "Tarefa excluída com sucesso!");
        }
        catch
        {
            return new Response<TodoTask?>(null, 500, "Não foi possível excluir a tarefa");
        }
    }

    public async Task<Response<TodoTask?>> GetByIdAsync(GetTodoTaskByIdRequest request)
    {
        try
        {
            var todoTask = await context.TodoTasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (todoTask is null)
                return new Response<TodoTask?>(null, 404, "Tarefa não encontrada");

            return new Response<TodoTask?>(todoTask);
        }
        catch
        {
            return new Response<TodoTask?>(null, 500, "Não foi possível recuperar a tarefa");
        }
    }

    public async Task<PagedResponse<List<TodoTask>?>> GetAllAsync(GetAllTodoTasksRequest request)
    {
        try
        {
            var query = context.TodoTasks.AsNoTracking();
            
            var todoTasks = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            var count = await query.CountAsync();

            return new PagedResponse<List<TodoTask>?>(todoTasks, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<TodoTask>?>(null, 500, "Não foi possível recuperar a tarefa");
        }
    }
}