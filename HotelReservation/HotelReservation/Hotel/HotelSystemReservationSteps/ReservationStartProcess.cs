using System;

namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class ReservationStartProcess : IHotelSystemReservationStep
    {
        public int Execute(HotelSystem reservationSystem)
        {
            Console.WriteLine("----==== RESERVATION PROCESS ====----");
            return 0;
        }
    }
}
