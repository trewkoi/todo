﻿namespace Todo.Core.Requests.Categories;

public class GetCategoryByIdRequest : Request
{
    public long Id { get; set; }
}