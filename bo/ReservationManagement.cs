using bo.Interface;
using dal;
using model;

namespace bo
{
    public class ReservationManagement : IReservationManagement
    {

        private ReservationRecord getReservationRecordOfUserAndBook(ReservationRecord record)
            => ReservationDAO.getReservationRecordByUserAndBook(record);

        public ReservationRecord removeReservation(ReservationRecord record)
        {
            ReservationRecord rr = getReservationRecordOfUserAndBook(record);
            if (rr != null)
            {
                ReservationDAO.removeReservation(rr);
                return rr;
            }
            else
            {
                throw new Exception("Can not find your reservation!");
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

        public List<ReservationRecord> getAllReservationRecordsOfUser(User user)
            => ReservationDAO.getAllReservationRecordsOfUser(user);

    }
}
