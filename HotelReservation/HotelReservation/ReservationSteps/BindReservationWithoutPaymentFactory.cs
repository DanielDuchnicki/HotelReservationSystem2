namespace HotelReservation.ReservationSteps
{
    public class BindReservationWithoutPaymentFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new BindReservationWithoutPayment();
    }
}
