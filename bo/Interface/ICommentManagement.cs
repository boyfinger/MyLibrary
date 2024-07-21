using model;

namespace bo.Interface
{
    public interface ICommentManagement
    {
        Comment getCommentByUserAndBook(Comment comment);
        Comment comment(Comment comment);
        Comment removeComment(Comment comment);
    }
}
