namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class HotelSystemReservationProcessFactory : HotelSystemReservationStepsFactory
    {
        public override IHotelSystemReservationStep Create() => new ReservationStartProcess();
    }
}
