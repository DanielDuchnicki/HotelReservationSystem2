using System;

namespace HotelReservation.ReservationSteps
{
    class StartNewReservation : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== STARTING NEW RESERVATION ====----");
        }
    }
}
