using Microsoft.Identity.Client;
using model;

namespace dal
{
    public class ReservationDAO
    {
        public static ReservationRecord getReservationRecordByUserAndBook(ReservationRecord record)
        {
            var db = new LibraryContext();
            return db.ReservationRecords.FirstOrDefault(r => r.UserId.Equals(record.UserId)
                && r.BookId.Equals(record.BookId));
        }

        public static void removeReservation(ReservationRecord record)
        {
            try
            {
                var db = new LibraryContext();
                db.ReservationRecords.Remove(record);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Remove reservation failed!");
            }
        }

        public static void insertNewReservation(ReservationRecord record)
        {
            try
            {
                var db = new LibraryContext();
                db.ReservationRecords.Add(record);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Reserving failed!");
            }
        }
    }
}
