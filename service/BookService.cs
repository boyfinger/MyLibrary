using bo;
using bo.Interface;
using model;
using service.Interfaces;

namespace service
{
    public class BookService : IBookService
    {
        private readonly IBookManagement iBookManagement;

        public BookService()
        {
            iBookManagement = new BookManagement();
        }

        public List<Book> getAllBooks() => iBookManagement.getAllBooks();

        public Book insertBook(Book book)
        {
            iBookManagement.insertBook(book);
            return book;
        }

        public Book updateBook(Book book) => iBookManagement.updateBook(book);

        public Book removeBook(Book book) => iBookManagement.removeBook(book);
    }
}
