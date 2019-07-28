namespace HotelReservation.ReservationSteps
{
    class DisplayHotelsFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new DisplayHotels();
    }
}
