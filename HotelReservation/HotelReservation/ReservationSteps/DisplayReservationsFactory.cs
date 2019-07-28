namespace HotelReservation.ReservationSteps
{
    class DisplayReservationsFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new DisplayReservations();
    }
}
