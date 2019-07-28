using System;

namespace HotelReservation.ReservationSteps
{
    class SelectHotel : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== SELECTING HOTEL ====----");
        }
    }
}
