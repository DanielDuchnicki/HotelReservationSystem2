using System;

namespace HotelReservation.ReservationSteps
{
    class DisplayHotels : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== DISPLAYING LIST OF HOTELS ====----");
        }
    }
}
