using model;

namespace bo.Interface
{
    public interface IBorrowManagement
    {
        List<BorrowRecord> getAllBorrowRecordsOfUser(User user);
        void borrow(BorrowRecord record);
        BorrowRecord returnBook(BorrowRecord record);
        BorrowRecord getBorrowRecordByUserAndBook(BorrowRecord record);
        BorrowRecord changeReturnDate(BorrowRecord record);
    }
}
