using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Mail
{
    public class SendingMailProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        public List<StepInput> stepInputs;
        public SendingMailProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
            stepInputs = new List<StepInput>();
        }
        public List<StepInput> GetStepInputs()
        {
            return stepInputs;
        }
        public virtual void Execute(List<StepInput> stepInputs)
        {
            _consolePrinter.Write("----==== SENDING MAIL PROCESS ====----");
        }
    }
}
