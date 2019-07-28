namespace HotelReservation.ReservationSteps
{
    class BindReservationWithPaymentFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new BindReservationWithPayment();
    }
}
