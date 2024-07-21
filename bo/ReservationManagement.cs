using bo.Interface;
using dal;
using model;

namespace bo
{
    public class ReservationManagement : IReservationManagement
    {

        private ReservationRecord getReservationRecordOfUserAndBook(ReservationRecord record)
            => ReservationDAO.getReservationRecordByUserAndBook(record);

        public void removeReservation(ReservationRecord record)
        {
            ReservationRecord rr = getReservationRecordOfUserAndBook(record);
            if (rr != null)
            {
                ReservationDAO.removeReservation(rr);
            }
            else
            {
                throw new Exception("Remove reservation failed!");
            }
        }

        public void reserve(ReservationRecord record)
        {
            ReservationRecord rr = getReservationRecordOfUserAndBook(record);
            if (rr == null)
            {
                ReservationDAO.insertNewReservation(record);
            }
            else
            {
                throw new Exception("You have already reserved this book!");
            }
        }

    }
}
