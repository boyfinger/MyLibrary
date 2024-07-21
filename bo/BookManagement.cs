﻿using bo.Interface;
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
        }
    }
}
