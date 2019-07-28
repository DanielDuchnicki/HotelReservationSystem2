using System;

namespace HotelReservation.ReservationSteps
{
    class AcceptPayment : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== ACCEPTING PAYMENT ====----");
        }
    }
}
