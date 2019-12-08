using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Payment
{
    public class PaymentProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        public List<StepInput> stepInputs;
        public PaymentProcess(ConsolePrinter consolePrinter)
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
