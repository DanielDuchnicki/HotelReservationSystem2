using System;

namespace HotelReservation.Payment
{
    public class PaymentProcess : IPaymentSystemReservationStep
    {
        public void Execute(IManagementSystem paymentSystem)
        {
            Console.WriteLine("----==== PAYMENT PROCESS ====----");
        }
    }
}
