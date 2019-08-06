namespace HotelReservation.Payment
{
    public class PaymentProcessFactory : PaymentSystemReservationStepsFactory
    {
        public override IPaymentSystemReservationStep Create() => new PaymentProcess();
    }
}
