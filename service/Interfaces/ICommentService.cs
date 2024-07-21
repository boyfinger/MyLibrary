using model;

namespace service.Interfaces
{
    public interface ICommentService
    {
        List<Comment> getAllCommentsOfUser(User user);
        Comment comment(Comment comment);
        Comment removeComment(Comment comment);
    }
}
