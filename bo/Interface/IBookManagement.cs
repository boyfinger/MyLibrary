using model;

namespace bo.Interface
{
    public interface IBookManagement
    {
        List<Book> getAllBooks();
        Book getBookById(int id);
        void updateBookAfterBorrowing(int bookId);
        void updateBookAfterReturning(int bookId);
        void insertBook(Book book);
        Book updateBook(Book book);
        Book removeBook(Book book);
    }
}
