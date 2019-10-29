namespace HotelReservation.ReservationSteps.Payment
{
    public class PaymentProcessData : IStepData
    {
        public double Price { get; private set; }
        public ReservationStepType ReservationStep { get; set; }

        public PaymentProcessData(double price)
        {
            ReservationStep = ReservationStepType.PaymentProcess;
            Price = price;
        }
    }
}
