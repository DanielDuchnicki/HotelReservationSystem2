using System;

namespace HotelReservation.ReservationSteps
{
    class ChangeHotelPrice : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== CHANGING HOTEL PRICE ====----");
        }
    }
}
