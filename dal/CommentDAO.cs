using Microsoft.EntityFrameworkCore;
using model;

namespace dal
{
    public class CommentDAO
    {
        public static Comment getCommentByUserAndBook(Comment comment)
        {
            var db = new LibraryContext();
            return db.Comments.FirstOrDefault(c => c.UserId == comment.UserId && c.BookId == comment.BookId);
        }

        public static void insertComment(Comment comment)
        {
            try
            {
                var db = new LibraryContext();
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Insert comment failed!");
            }
        }

        public static void updateComment(Comment comment)
        {
            try
            {
                var db = new LibraryContext();
                db.Entry<Comment>(comment).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Update comment failed!");
            }
        }

        public static void removeComment(Comment comment)
        {
            try
            {
                var db = new LibraryContext();
                db.Comments.Remove(comment);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Remove comment failed!");
            }
        }
    }
}
