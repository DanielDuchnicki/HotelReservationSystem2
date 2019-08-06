using System;

namespace HotelReservation.Mail
{
    public class SendingMailProcess : IMailSystemReservationStep
    {
        public void Execute(IManagementSystem mailSystem)
        {
            Console.WriteLine("----==== SENDING MAIL PROCESS ====----");
        }
    }
}
