using System;

namespace HotelReservation.ReservationSteps.Payment
{
    public class PaymentProcess : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== PAYMENT PROCESS ====----");
        }
    }
}
