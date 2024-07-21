using bo.Interface;
using dal;
using model;

namespace bo
{
    public class CommentManagement : ICommentManagement
    {
        public Comment getCommentByUserAndBook(Comment comment) => CommentDAO.getCommentByUserAndBook(comment);

        public Comment comment(Comment comment)
        {
            Comment c = CommentDAO.getCommentByUserAndBook(comment);
            if (c != null)
            {
                CommentDAO.updateComment(comment);
            }
            else
            {
                CommentDAO.insertComment(comment);
            }

            return comment;
        }

        public Comment removeComment(Comment comment)
        {
            Comment c = CommentDAO.getCommentByUserAndBook(comment);
            if (c != null)
            {
                CommentDAO.removeComment(c);
                return c;
            }
            else
            {
                throw new Exception("Can not find your comment!");
            }
        }
    }
}
