namespace HotelReservation.ReservationSteps
{
    class DisplayPaymentsFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new DisplayPayments();
    }
}
