using model;

namespace dal
{
    public class BorrowDAO
    {
        private static List<BorrowRecord> getAll()
        {
            var db = new LibraryContext();
            return db.BorrowRecords.ToList();
        }
        public static List<BorrowRecord> getAllBorrowRecordsOfUser(User user)
        {
            var db = new LibraryContext();
            return db.BorrowRecords.Where(record => record.UserId.Equals(user.UserId)).ToList();
        }

        public static void insertBorrowRecord(BorrowRecord record)
        {
            try
            {
                var db = new LibraryContext();
                db.BorrowRecords.Add(record);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Borrowing failed!");
            }
        }

        public static BorrowRecord getBorrowRecordByUserAndBook(BorrowRecord record)
        {
            var db = new LibraryContext();
            return db.BorrowRecords.FirstOrDefault(br => br.UserId == record.UserId 
                && br.BookId == record.BookId);
        }
    }
}
