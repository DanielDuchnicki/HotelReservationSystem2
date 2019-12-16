using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Mail
{
    internal class SendingMailProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private StepInput name = new StepInput(InputType.Name);
        private StepInput email = new StepInput(InputType.EmailAddress);
        private List<StepInput> stepInputs;
        public SendingMailProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
            stepInputs = new List<StepInput> { name, email };
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
