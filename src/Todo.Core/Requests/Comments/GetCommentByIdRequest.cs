namespace Todo.Core.Requests.Comments;

public class GetCommentByIdRequest : Request
{
    public long Id { get; set; }
}