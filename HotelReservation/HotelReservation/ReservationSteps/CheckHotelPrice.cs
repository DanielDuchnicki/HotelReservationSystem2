using System;

namespace HotelReservation.ReservationSteps
{
    class CheckHotelPrice : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== CHECKING HOTEL PRICE ====----");
        }
    }
}
