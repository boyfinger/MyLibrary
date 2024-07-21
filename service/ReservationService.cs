using bo;
using bo.Interface;
using model;
using service.Interfaces;

namespace service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationManagement iReservationManagement;

        public ReservationService()
        {
            iReservationManagement = new ReservationManagement();
        }
        public void reserve(ReservationRecord record)
        {
            record.ReservationDate = DateOnly.FromDateTime(DateTime.Now);
            iReservationManagement.reserve(record);
        }
    }
}
