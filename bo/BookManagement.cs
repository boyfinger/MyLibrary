using bo.Interface;
using dal;
using model;

namespace bo
{
    public class BookManagement : IBookManagement
    {
        public List<Book> getAllBooks() => BookDAO.getAllBooks();

        public Book getBookById(int id) => BookDAO.getBookById(id);

        public void updateBookAfterBorrowing(int bookId)
        {
            Book book = BookDAO.getBookById(bookId);
            if (book != null)
            {
                byte quantity = (byte)(book.Quantity);
                if (quantity == 0)
                {
                    throw new Exception("This book is out of stock!");
                }
                book.Quantity = (byte?)(quantity - 1);
                BookDAO.updateBook(book);
            }
            else
            {
                throw new Exception("Borrowing failed!");
            }
        }

        public void updateBookAfterReturning(int bookId)
        {
            Book book = BookDAO.getBookById(bookId);
            if (book != null)
            {
                book.Quantity = (byte?)(book.Quantity + 1);
                BookDAO.updateBook(book);
            }
            else
            {
                throw new Exception("Returning failed!");
            }
        }

        public void insertBook(Book book) => BookDAO.insertBook(book);

        public Book updateBook(Book book)
        {
            Book b = BookDAO.getBookById(book.BookId);
            if (b == null)
            {
                throw new Exception("Book not found!");
            }
            else
            {
                BookDAO.updateBook(book);
                return book;
            }
        }

        public Book removeBook(Book book)
        {
            Book b = BookDAO.getBookById(book.BookId);
            if (b != null)
            {
                BookDAO.removeBook(book);
                return b;
            }
            else
            {
                throw new Exception("Book not found!");
            }
        }
    }
}
