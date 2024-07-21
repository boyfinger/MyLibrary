using model;

namespace bo.Interface
{
    public interface IReservationManagement
    {
        void removeReservation(ReservationRecord record);
        void reserve(ReservationRecord record);
    }
}
