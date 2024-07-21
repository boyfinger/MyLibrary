using model;

namespace service.Interfaces
{
    public interface IBorrowService
    {
        List<Book> getAllUnborrowedBookByUser(User user);
        BorrowRecord borrow(BorrowRecord record);
        List<BorrowRecord> getAllBorrowRecordsOfUser(User user);
        BorrowRecord returnBook(BorrowRecord record);
        BorrowRecord changeReturnDate(BorrowRecord record);
    }
}
