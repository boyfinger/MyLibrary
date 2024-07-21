using bo;
using bo.Interface;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using model;
using service.Interfaces;

namespace service
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookManagement iBookManagement;
        private readonly IBorrowManagement iBorrowManagement;
        private readonly IReservationManagement iReservationManagement;

        public BorrowService()
        {
            iBookManagement = new BookManagement();
            iBorrowManagement = new BorrowManagement();
            iReservationManagement = new ReservationManagement();
        }

        private List<Book> getBorrowedBookListByUser(User user)
        {
            var ret = new List<Book>();
            foreach (BorrowRecord record in iBorrowManagement.getAllBorrowRecordsOfUser(user))
            {
                var book = iBookManagement.getBookById(record.BookId);
                ret.Add(book);
            }
            return ret;
        }

        private bool isBookInList(Book book, List<Book> list)
        {
            foreach (Book b in list)
            {
                if (b.BookId == book.BookId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Book> getAllUnborrowedBookByUser(User user)
        {
            List<Book> borrowed = getBorrowedBookListByUser(user);
            List<Book> ret = new List<Book>();

            foreach(Book book in iBookManagement.getAllBooks())
            {
                if (!isBookInList(book, borrowed))
                {
                    ret.Add(book);
                }
            }
            return ret; 
        }

        public BorrowRecord borrow(BorrowRecord borrowRecord)
        {
            ReservationRecord reservationRecord = new ReservationRecord
            {
                UserId = borrowRecord.UserId,
                BookId = borrowRecord.BookId,
            };
            borrowRecord.BorrowDate = DateOnly.FromDateTime(DateTime.Now);
            try
            {
                iReservationManagement.removeReservation(reservationRecord);
            }
            catch
            {

            }
            iBookManagement.updateBookAfterBorrowing(borrowRecord.BookId);
            iBorrowManagement.borrow(borrowRecord);

            borrowRecord.Book = iBookManagement.getBookById(borrowRecord.BookId);
            return borrowRecord;
        }

        public List<BorrowRecord> getAllBorrowRecordsOfUser(User user)
        {
            var ret = new List<BorrowRecord>();
            foreach (BorrowRecord record in iBorrowManagement.getAllBorrowRecordsOfUser(user))
            {
                var book = iBookManagement.getBookById(record.BookId);
                record.Book = book;
                ret.Add(record);
            }
            return ret;
        }

        public BorrowRecord returnBook(BorrowRecord record)
        {
            BorrowRecord borrowRecord = iBorrowManagement.returnBook(record);
            iBookManagement.updateBookAfterReturning(record.BookId);

            borrowRecord.Book = iBookManagement.getBookById(borrowRecord.BookId);
            return borrowRecord;
        }

        public BorrowRecord changeReturnDate(BorrowRecord record)
        {
            BorrowRecord borrowRecord = iBorrowManagement.changeReturnDate(record);

            borrowRecord.Book = iBookManagement.getBookById(borrowRecord.BookId);
            return borrowRecord;
        }
    }
}
