using model;

namespace service.Interfaces
{
    public interface IBookService
    {
        List<Book> getAllBooks();
        Book insertBook(Book book);
        Book updateBook(Book book);
        Book removeBook(Book book);
    }
}
