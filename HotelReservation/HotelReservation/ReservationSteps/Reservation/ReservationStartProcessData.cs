namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcessData : IStepData
    {
        public int HotelId { get; private set; }
        public ReservationStepType ReservationStep { get; set; }

        public ReservationStartProcessData(int hotelId)
        {
            ReservationStep = ReservationStepType.ReservationProcess;
            HotelId = hotelId;
        }
    }
}
