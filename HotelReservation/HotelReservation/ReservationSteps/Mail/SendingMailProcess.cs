using System;

namespace HotelReservation.ReservationSteps.Mail
{
    public class SendingMailProcess : IReservationStep
    {
        public void Execute(IStepData stepData)
        {
            var sendingMailProcessData = stepData as SendingMailProcessData;
            Console.WriteLine("----==== SENDING MAIL PROCESS ====----");
            Console.WriteLine(sendingMailProcessData.EmailAddress);
        }
    }
}
