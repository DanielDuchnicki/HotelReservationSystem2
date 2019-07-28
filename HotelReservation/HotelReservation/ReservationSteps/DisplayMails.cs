using System;

namespace HotelReservation.ReservationSteps
{
    class DisplayMails : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== DISPLAYING LIST OF MAILS ====----");
        }
    }
}
