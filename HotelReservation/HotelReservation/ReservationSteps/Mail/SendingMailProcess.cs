using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Mail
{
    public class SendingMailProcess : IReservationStep
    {
        public void Execute(ConsolePrinter consolePrinter, List<StepInput> stepData)
        {
            new ConsolePrinter().Execute("----==== SENDING MAIL PROCESS ====----");
        }
    }
}
