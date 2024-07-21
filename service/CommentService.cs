using bo;
using bo.Interface;
using model;
using service.Interfaces;

namespace service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentManagement iCommentManagement;
        private readonly IBookManagement iBookManagement;

        public CommentService()
        {
            iCommentManagement = new CommentManagement();
            iBookManagement = new BookManagement();
        }

        public List<Comment> getAllCommentsOfUser(User user)
        {
            var ret = new List<Comment>();
            foreach (Book book in iBookManagement.getAllBooks())
            {
                Comment comment = new Comment
                {
                    UserId = user.UserId,
                    BookId = book.BookId,
                    Book = iBookManagement.getBookById(book.BookId),
                };

                Comment c = iCommentManagement.getCommentByUserAndBook(comment);
                if (c != null)
                {
                    comment.Comments = c.Comments;
                    comment.Rating = c.Rating;
                }
                ret.Add(comment);
            }
            return ret;
        }

        public Comment comment(Comment comment)
        { 
            Comment c = iCommentManagement.comment(comment);
            c.Book = iBookManagement.getBookById(c.BookId);
            return c;
        }

        public Comment removeComment(Comment comment)
        {
            Comment c = iCommentManagement.removeComment(comment);
            c.Book = iBookManagement.getBookById(c.BookId);
            return c;
        }
    }
}
