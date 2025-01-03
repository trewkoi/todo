using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Requests.Comments;

public class CreateCommentRequest : Request
{
    [Required(ErrorMessage = "Tarefa inválida")]
    public long TaskId { get; set; }

    [Required(ErrorMessage = "Autor inválido")]
    public long AuthorId { get; set; }

    [Required(ErrorMessage = "Conteúdo inválido")]
    [MaxLength(100, ErrorMessage = "O conteúdo deve conter até 100 caracteres")]
    public string Content { get; set; } = string.Empty;

}