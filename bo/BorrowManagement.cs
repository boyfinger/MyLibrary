using bo.Interface;
using dal;
using model;

namespace bo
{
    public class BorrowManagement : IBorrowManagement
    {
        public List<BorrowRecord> getAllBorrowRecordsOfUser(User user) => BorrowDAO.getAllBorrowRecordsOfUser(user);

        public void borrow(BorrowRecord record)
        {
            BorrowRecord borrowRecord = BorrowDAO.getBorrowRecordByUserAndBook(record);
            if (borrowRecord == null)
            {
                BorrowDAO.insertBorrowRecord(record);
            }
        }
    }
}
