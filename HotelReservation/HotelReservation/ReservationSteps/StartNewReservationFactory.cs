namespace HotelReservation.ReservationSteps
{
    class StartNewReservationFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new StartNewReservation();
    }
}
