using model;

namespace bo.Interface
{
    public interface IBorrowManagement
    {
        List<BorrowRecord> getAllBorrowRecordsOfUser(User user);

        void borrow(BorrowRecord record);
    }
}
