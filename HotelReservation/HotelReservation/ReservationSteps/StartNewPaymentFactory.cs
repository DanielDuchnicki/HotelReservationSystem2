namespace HotelReservation.ReservationSteps
{
    class StartNewPaymentFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new StartNewPayment();
    }
}
