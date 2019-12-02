using System.Collections.Generic;
using System.Net.Mail;

namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private StepInput name = new StepInput(typeof(string), QuestionIdentifier.Name);
        private StepInput email = new StepInput(typeof(MailAddress), QuestionIdentifier.EmailAddress);
        private List<StepInput> stepInputs;

        public ReservationStartProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
            stepInputs = new List<StepInput>{name};
        }

        public List<StepInput> GetStepInputs()
        {
            return stepInputs;
        }

        public void Execute()
        {
            _consolePrinter.Write("----==== RESERVATION PROCESS ====----");
            _consolePrinter.Write(name.Value);
        }
    }
}
