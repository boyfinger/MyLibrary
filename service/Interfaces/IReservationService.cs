using model;

namespace service.Interfaces
{
    public interface IReservationService
    {
        ReservationRecord reserve(ReservationRecord record);
        List<ReservationRecord> getAllReservationRecordsOfUser(User user);
        ReservationRecord removeReservation(ReservationRecord record);
    }
}
