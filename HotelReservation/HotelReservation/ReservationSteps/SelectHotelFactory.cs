namespace HotelReservation.ReservationSteps
{
    class SelectHotelFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new SelectHotel();
    }
}
