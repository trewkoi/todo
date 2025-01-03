using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Requests.Comments;

public class UpdateCommentRequest : Request
{
    [Required(ErrorMessage = "Conteúdo inválido")]
    [MaxLength(100, ErrorMessage = "O conteúdo deve conter até 100 caracteres")]
    public string Content { get; set; } = string.Empty;
}