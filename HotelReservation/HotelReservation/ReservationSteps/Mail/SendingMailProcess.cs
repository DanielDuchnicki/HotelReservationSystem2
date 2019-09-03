using System;

namespace HotelReservation.ReservationSteps.Mail
{
    public class SendingMailProcess : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== SENDING MAIL PROCESS ====----");
        }
    }
}
