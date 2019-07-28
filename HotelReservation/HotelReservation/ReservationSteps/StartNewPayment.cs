using System;

namespace HotelReservation.ReservationSteps
{
    class StartNewPayment : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== STARTING NEW PAYMENT ====----");
        }
    }
}
