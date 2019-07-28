using System;

namespace HotelReservation.ReservationSteps
{
    class DisplayReservations : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== DISPLAYING LIST OF RESERVATIONS ====----");
        }
    }
}
