using model;

namespace bo.Interface
{
    public interface IReservationManagement
    {
        ReservationRecord removeReservation(ReservationRecord record);
        void reserve(ReservationRecord record);
        List<ReservationRecord> getAllReservationRecordsOfUser(User user);
    }
}
