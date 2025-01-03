using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Requests.Categories;

public class UpdateCategoryRequest : Request
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Descrição inválida")]
    public string Description { get; set; } = string.Empty;
}