namespace HotelReservation.ReservationSteps
{
    class CheckHotelPriceFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new CheckHotelPrice();
    }
}
