namespace HotelReservation.Payment
{
    public abstract class PaymentSystemReservationStepsFactory
    {
        public abstract IPaymentSystemReservationStep Create();
    }
}
