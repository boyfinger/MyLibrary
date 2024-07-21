using model;

namespace bo.Interface
{
    public interface IBookManagement
    {
        List<Book> getAllBooks();
        Book getBookById(int id);
        void updateBookAfterBorrowing(int bookId);
    }
}
