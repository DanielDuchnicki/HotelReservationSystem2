namespace HotelReservation.ReservationSteps
{
    public class ChangeHotelPriceFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new ChangeHotelPrice();
    }
}