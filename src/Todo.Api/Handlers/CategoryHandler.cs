﻿using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests.Categories;
using Todo.Core.Responses;

namespace Todo.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, 201, "Categoria criada com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
                return new Response<Category?>(null, 404, "Categoria não encontrada");

            category.Name = request.Name;
            category.Description = request.Description;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Categoria atualizada com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível atualizar a categoria");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
                return new Response<Category?>(null, 404, "Categoria não encontrada");

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, message: "Categoria removida com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível excluir a categoria");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            return category is null 
                ? new Response<Category?>(null, 404, "Categoria não encontrada") 
                : new Response<Category?>(category);
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível recuperar a categoria");
        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var query = context.Categories.AsNoTracking();
            
            var categories = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            var count = await query.CountAsync();
            
            return new PagedResponse<List<Category>?>(categories, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Category>?>(null, 500, "Não foi possível recuperar as categorias");
        }
    }
}