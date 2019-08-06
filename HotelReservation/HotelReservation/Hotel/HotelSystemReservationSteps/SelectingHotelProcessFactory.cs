namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class SelectingHotelProcessFactory : HotelSystemReservationStepsFactory
    {
        public override IHotelSystemReservationStep Create() => new SelectingHotelProcess();
    }
}
