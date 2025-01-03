using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Requests.Comments;
using Todo.Core.Responses;

namespace Todo.Core.Handlers;

public interface ICommentHandler
{
    Task<Response<Comment?>> CreateAsync(CreateCommentRequest request);
    Task<Response<Comment?>> UpdateAsync(UpdateCommentRequest request);
    Task<Response<Comment?>> DeleteAsync(DeleteCommentRequest request);
    Task<Response<Comment?>> GetByIdAsync(GetCommentByIdRequest request);
    Task<PagedResponse<List<Comment>>> GetByTaskIdAsync(GetCommentsByTaskIdRequest request);
}