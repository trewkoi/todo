using System.ComponentModel.DataAnnotations;
using Todo.Core.Enums;

namespace Todo.Core.Requests.TodoTasks;

public class UpdateTodoTaskRequest : Request
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Título inválido")]
    [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Descrição inválida")]
    [MaxLength(120, ErrorMessage = "A descrição deve conter até 80 caracteres")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Data inválida")]
    public DateTime? UpdatedAt { get; set; }
    
    [Required(ErrorMessage = "Data inválida")]
    public DateTime? DueDate { get; set; }
    
    [Required(ErrorMessage = "Prioridade inválida")]
    public ETaskPriority Priority { get; set; }
    
    [Required(ErrorMessage = "Status inválido")]
    public ETaskStatus Status { get; set; }
    
    [Required(ErrorMessage = "Usuário inválido")]
    public long AssignedTo { get; set; }
    
    [Required(ErrorMessage = "Categoria inválida")]
    public long CategoryId { get; set; }
}