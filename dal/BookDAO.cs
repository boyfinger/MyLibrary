﻿using Microsoft.EntityFrameworkCore;
using model;

namespace dal
{
    public class BookDAO
    {
        public static List<Book> getAllBooks()
        {
            var db = new LibraryContext();
            return db.Books.ToList();
        }

        public static Book getBookById(int id)
        {
            var db = new LibraryContext();
            return db.Books.FirstOrDefault(book => book.BookId.Equals(id));
        }

        public static void updateBook(Book book)
        {
            try
            {
                var db = new LibraryContext();
                db.Entry<Book>(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Updating book failed!");
            }
        }
    }
}