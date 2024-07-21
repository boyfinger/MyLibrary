using bo;
using bo.Interface;
using model;
using service.Interfaces;

namespace service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationManagement iReservationManagement;
        private readonly IBorrowManagement iBorrowManagement;
        private readonly IBookManagement iBookManagement;

        public ReservationService()
        {
            iReservationManagement = new ReservationManagement();
            iBorrowManagement = new BorrowManagement();
            iBookManagement = new BookManagement();
        }
        public ReservationRecord reserve(ReservationRecord record)
        {
            BorrowRecord borrowRecord = new BorrowRecord
            {
                UserId = record.UserId,
                BookId = record.BookId,
            };
            if (iBorrowManagement.getBorrowRecordByUserAndBook(borrowRecord) != null)
            {
                throw new Exception("You have already borrow this book!");
            }

            record.ReservationDate = DateOnly.FromDateTime(DateTime.Now);
            iReservationManagement.reserve(record);

            record.Book = iBookManagement.getBookById(record.BookId);
            return record;
        }

        public List<ReservationRecord> getAllReservationRecordsOfUser(User user)
        {
            var ret = new List<ReservationRecord>();
            foreach (ReservationRecord record in iReservationManagement.getAllReservationRecordsOfUser(user))
            {
                record.Book = iBookManagement.getBookById(record.BookId);
                ret.Add(record);
            }
            return ret;
        }

        public ReservationRecord removeReservation(ReservationRecord record)
        {
            ReservationRecord reservationRecord = iReservationManagement.removeReservation(record);

            reservationRecord.Book = iBookManagement.getBookById(reservationRecord.BookId);
            return reservationRecord;
        }
    }
}
