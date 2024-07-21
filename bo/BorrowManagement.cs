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
            else
            {
                throw new Exception("You have already borrowed this book!");
            }
        }

        public BorrowRecord returnBook(BorrowRecord record)
        {
            BorrowRecord borrowRecord = BorrowDAO.getBorrowRecordByUserAndBook(record);
            if (borrowRecord != null)
            {
                BorrowDAO.removeBorrowRecord(record);
                return borrowRecord;
            }
            else
            {
                throw new Exception("Can not find your borrowing record!");
            }
        }

        public BorrowRecord getBorrowRecordByUserAndBook(BorrowRecord record)
            => BorrowDAO.getBorrowRecordByUserAndBook(record);

        public BorrowRecord changeReturnDate(BorrowRecord record)
        {
            BorrowRecord borrowRecord = BorrowDAO.getBorrowRecordByUserAndBook(record);
            if (borrowRecord != null) 
            {
                BorrowDAO.updateBorrowRecord(record);
                return record;
            }
            else
            {
                throw new Exception("Can not find your borrow record!");
            }
        }
    }
}
