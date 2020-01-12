using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Payment
{
    internal class PaymentProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private List<InputType> _requiredInputTypes = new List<InputType>();

        public PaymentProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
        }

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual void Execute(List<StepInput> stepInputs)
        {
            _consolePrinter.Write("----==== PAYMENT PROCESS ====----");
        }
    }
}
