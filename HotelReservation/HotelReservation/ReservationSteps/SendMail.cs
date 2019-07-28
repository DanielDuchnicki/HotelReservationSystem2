using System;

namespace HotelReservation.ReservationSteps
{
    class SendMail : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== SENDING MAIL ====----");
        }
    }
}
