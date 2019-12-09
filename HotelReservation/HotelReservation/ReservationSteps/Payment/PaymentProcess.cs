using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Payment
{
    internal class PaymentProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private List<StepInput> stepInputs;
        internal PaymentProcess(ConsolePrinter consolePrinter)
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
            _consolePrinter.Write("----==== PAYMENT PROCESS ====----");
        }
    }
}
