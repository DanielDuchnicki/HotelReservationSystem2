namespace HotelReservation.ReservationSteps
{
    class AcceptPaymentFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new AcceptPayment();
    }
}
