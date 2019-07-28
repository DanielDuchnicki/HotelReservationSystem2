using System;

namespace HotelReservation.ReservationSteps
{
    class DisplayPayments : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== DISPLAYING LIST OF PAYMENTS ====----");
        }
    }
}
